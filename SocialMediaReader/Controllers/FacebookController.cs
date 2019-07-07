using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SocialMediaReader.Controllers
{
    [Authorize]
    public class FacebookController : Controller
    {

        // GET: Facebook
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Posts()
        {
            Models.SocialMedia.Facebook.FacebookClient facebookClient = new Models.SocialMedia.Facebook.FacebookClient();
            facebookClient.HttpContext = HttpContext;

            Models.SocialMedia.Facebook.posts posts = await facebookClient.Posts();

            return (View(posts));

            ////Get Access Token
            //var currentClaims = await UserManager.GetClaimsAsync(HttpContext.User.Identity.GetUserId());
            //var accesstoken = currentClaims.FirstOrDefault(x => x.Type == "urn:tokens:facebook");

            //if (accesstoken == null)
            //{
            //    return (new HttpStatusCodeResult(HttpStatusCode.NotFound, "Token not found."));
            //}

            ////Format a url to retrieve posts or feed data from Facebook
            //string url = String.Format("https://graph.facebook.com/me?fields=id,name,feed.limit(1000){{attachments,message,story,created_time,likes}}&access_token={0}", accesstoken.Value);

            ////Generate a web request using the url
            //HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //request.Method = "GET";

            ////Ask for data from the server
            //using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
            //{
            //    StreamReader reader = new StreamReader(response.GetResponseStream());

            //    //Place result into a string
            //    string result = await reader.ReadToEndAsync();

            //    //Convert result to JSON Object
            //    dynamic jsonObj = System.Web.Helpers.Json.Decode(result);

            //    Models.SocialMedia.Facebook.posts posts = new Models.SocialMedia.Facebook.posts(jsonObj);

            //    ViewBag.JSON = result;

            //    return View(posts);
            //}

            
        }
    }
}