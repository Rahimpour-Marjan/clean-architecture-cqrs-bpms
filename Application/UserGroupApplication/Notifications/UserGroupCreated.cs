using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;
using Newtonsoft.Json;
using System.Text;

namespace Portal.Application.UserGroupApplication.Notifications
{
    public class UserGroupCreated
    {
        public class Notification : INotification, ICommittableRequest
        {
            public int Id { get; set; }
            public string ServiceUri { get; set; }
            public string ServiceName { get; set; }
        }

        public class HandlerNotification : INotificationHandler<Notification>
        {
            private readonly IUnitOfWork _uow;
            public HandlerNotification(IUnitOfWork uow)
            {
                _uow = uow;
            }
            public async Task Handle(Notification request, CancellationToken cancellationToken)
            {
                try
                {
                    var userGroup = await _uow.UserGroupRepository.FindById(request.Id);
                    if (userGroup != null)
                    {
                        var stringParams = await Task.Run(() => JsonConvert.SerializeObject(new
                        {
                        }));
                        var httpContent = new StringContent(stringParams, Encoding.UTF8, "application/json");
                        using (var client = new HttpClient())
                        {
                            string _serviceUri = request.ServiceUri + request.ServiceName + "/api/GetTaskNames/" + "ServiceRequest";
                            client.BaseAddress = new Uri(_serviceUri);
                            client.DefaultRequestHeaders.Accept.Clear();
                            HttpResponseMessage httpResponse = await client.PostAsync(_serviceUri, httpContent);
                            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK && httpResponse.Content != null)
                            {
                                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                                var resultSet = JsonConvert.DeserializeObject<ReturnClass>(responseContent);
                                if (resultSet != null)
                                {
                                    if (resultSet.ReturnCode == 0)
                                    {
                                        var apiResult = resultSet.Result;
                                        //foreach (var item in apiResult)
                                        //{

                                        //}

                                        await Task.CompletedTask;

                                    }
                                }
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }


            }

        }
    }
}
