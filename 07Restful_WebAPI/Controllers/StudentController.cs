using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _07Restful_WebAPI.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace _07Restful_WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        教務系統Entities db = new 教務系統Entities();

        // GET: 
        public IEnumerable<學生> Get()
        {
            return db.學生;
        }

        // GET: 
        public IHttpActionResult Get(string id)
        {
            var stu = db.學生.Find(id);   //若找的是pk可直接用find即可，不用寫where
            if (stu == null)
                return NotFound();

            return Ok(stu); //回傳status狀態碼200，表示傳送資料成功
        }

        // POST: 
        public IHttpActionResult Post([FromBody]學生 stu)
        {
            if (!ModelState.IsValid) {          //資料驗證通過時才可做資料新增
                return BadRequest(ModelState);
            }

            db.學生.Add(stu);
            try
            {
                db.SaveChanges();
            }
            catch(DbUpdateException) {
                if (db.學生.Count(m => m.學號 == stu.學號) > 0)
                    return Conflict();
                else
                    throw;      //拋出例外
            }
            

            return CreatedAtRoute("DefaultApi", new { id = stu.學號 }, stu);        //第一個參數為apiname，可自行修改，若要改時，需到app_start>webapiconfig中改route名稱
        }

        // PUT: 
        public IHttpActionResult Put(string id, [FromBody]學生 stu)
        {
            if (!ModelState.IsValid)
            {         
                return BadRequest(ModelState);
            }
            if (id!= stu.學號)
            {
                return BadRequest();
            }
            //修改資料時不能用db.學生.add，否則會發生pk重複
            db.Entry(stu).State=EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (db.學生.Count(m => m.學號 == stu.學號) > 0)
                    return Conflict();
                else
                    throw;     
            }


            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: 
        public IHttpActionResult Delete(string id)
        {
            var stu = db.學生.Find(id);
            if (stu == null)
                return NotFound();

            db.學生.Remove(stu);
            db.SaveChanges();

            return Ok(stu);
        }
    }
}
