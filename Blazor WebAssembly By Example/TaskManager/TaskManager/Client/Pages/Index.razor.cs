using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaskManager.Shared;

namespace TaskManager.Client.Pages
{
    public partial class Index
    {
        [Inject] public HttpClient Http { get; set; }
        private IList<TaskItem> tasks;
        private string error;
        private string newTask;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                string requestUri = "TaskItems";
                tasks = await Http.GetFromJsonAsync<IList<TaskItem>>(requestUri);
            }
            catch(Exception)
            {
                error = "Error encountered";
            }
        }

        private async Task CheckboxChecked(TaskItem task)
        {
            task.IsComplete = !task.IsComplete;
            string requestUri = $"TaskItems/{task.TaskItemId}";
            var response = await Http.PutAsJsonAsync<TaskItem>(requestUri, task);

            if(!response.IsSuccessStatusCode)
            {
                error = response.ReasonPhrase;
            }
        }

        private async Task DeleteTask(TaskItem task)
        {
            tasks.Remove(task);
            string requestUri = $"TaskItems/{task.TaskItemId}";
            var response = await Http.DeleteAsync(requestUri);

            if(!response.IsSuccessStatusCode)
            {
                error = response.ReasonPhrase;
            }
        }

        private async Task AddTask()
        {
            if(!string.IsNullOrWhiteSpace(newTask))
            {
                TaskItem newTaskItem = new TaskItem()
                {
                    TaskName = newTask,
                    IsComplete = false
                };
                tasks.Add(newTaskItem);

                string requestUri = "TaskItems";
                var response = await Http.PostAsJsonAsync(requestUri, newTaskItem);

                if(response.IsSuccessStatusCode)
                {
                    newTask = string.Empty;
                    var task = await response.Content.ReadFromJsonAsync<TaskItem>();
                }
                else
                {
                    error = response.ReasonPhrase;
                }
            }
        }
    }
}
