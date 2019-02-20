using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    public class DataController : Controller
    {
        [Route("api/Select")]
        [HttpGet]
        public ArrayList Select()
        {
            ArrayList resultList = null;
            Database db = new Database(DataBaseInfo.RealDBInfo());
            Hashtable resultMap = db.GetReader("select bNo, bTitle, bContents, delYn, CONVERT(CHAR(10), GETDATE(), 111)regDate from [Board];");
            if (Convert.ToInt32(resultMap["MsgCode"]) == -1)
            {
                Console.WriteLine(resultMap["Msg"].ToString());
            }
            else
            {
                resultList = (ArrayList)resultMap["Data"];
            }
            return resultList;
        }
    }
}
