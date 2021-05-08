using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ConsumeWebAPI.Model;
using Newtonsoft.Json;
using RestSharp;

namespace ConsumeWebAPI.Controllers
{
    public class ConsumToDoItemController : Controller
    {
        // GET: ConsumToDoItem
        public ActionResult Index()
        {
            string url = "https://localhost:44370/api/todoitems/";
            var client = new RestClient(url);

            var request = new RestRequest();
            IRestResponse<List<ToDoItem>> response = client.Get<List<ToDoItem>>(request);
            var data = response.Data;
            return View(data);
           
        }


        //*****************
        // GET: ToDoItems2/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoItem toDoItem)
        {


            string url = "https://localhost:44370/api/todoitems/";
            var client = new RestClient(url);

            var request = new RestRequest("", Method.POST);
            request.AddJsonBody(toDoItem);
            request.RequestFormat = DataFormat.Json;

            var restClient = new RestClient(url);
            var response = restClient.Post(request);

            return RedirectToAction(nameof(Index));

        }



        public ActionResult Edit(int id)
        {
            string url = "https://localhost:44370/api/todoitems/" + id.ToString();
            var client = new RestClient(url);

            var request = new RestRequest();
            IRestResponse<List<ToDoItem>> response = client.Get<List<ToDoItem>>(request);

            var data = response.Data.FirstOrDefault();


            return View(data);
        }

        public ActionResult EditToSave(ToDoItem toDoItem)
        {

            string url = "https://localhost:44370/api/todoitems/" + toDoItem.ID.ToString();
            var client = new RestClient(url);

            var request = new RestRequest("", Method.PUT);

            request.AddJsonBody(toDoItem);
            client.Execute(request);

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Details(long ID)
        {
            
            var client = new RestClient("https://localhost:44370/api/todoitems/" + ID);
            var request = new RestRequest();

            var response = client.Get<ToDoItem>(request);


           var item = response.Data;


            return View(item);
        }


        public ActionResult Delete(long id)
        {


            string url = "https://localhost:44370/api/todoitems/" + id.ToString();
            var client = new RestClient(url);

            var request = new RestRequest("", Method.DELETE);

            client.Execute(request);

            return RedirectToAction(nameof(Index));

        }


        private List<ToDoItem> GetItemById(long id)
        {

            string url = "https://localhost:44370/api/todoitems/" + id.ToString();
            var client = new RestClient(url);

            var request = new RestRequest();
            IRestResponse<List<ToDoItem>> response = client.Get<List<ToDoItem>>(request);
            var data = response.Data;

            return (data);
        }
    }
}