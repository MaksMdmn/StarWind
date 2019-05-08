using Microsoft.AspNetCore.Mvc;
using TestRESTService.Repositories.Interfaces;

namespace TestRESTService.Controllers
{
    // POSTMAN code for sending a few async requests (FOR TEST PURPOSES).

            //const testRequest = {
            //url: 'http://localhost:5000/Test/client/1/addAge',
            //method: 'POST',
            //};
            //  pm.sendRequest(testRequest, function (err, res) {
            //  console.log(err? err : res.json());
            //});
            //  pm.sendRequest(testRequest, function (err, res) {
            //  console.log(err? err : res.json());
            //});
            //  pm.sendRequest(testRequest, function (err, res) {
            //  console.log(err? err : res.json());
            //});
            //  pm.sendRequest(testRequest, function (err, res) {
            //  console.log(err? err : res.json());
            //});

    [Route("Test")]
    public class ClientController : Controller
    {
        IClientRepository _repo;
        static readonly object _lock = new object();

        public ClientController(IClientRepository repo)
        {
            _repo = repo;
        }

        [Route("client/{id:int}")]
        [HttpGet]
        public JsonResult GetClient(int id)
        {
            return Json(_repo.GetClient(id));
        }

        [Route("client/{id:int}/addAge")]
        [HttpPost]
        public JsonResult IncreaseClientsAge(int id)
        {
            lock (_lock)
            {
                Models.Client client = _repo.GetClient(id);
                client.Age++;
                _repo.UpdateClient(client);

                return Json(client);
            }
        }
    }
}
