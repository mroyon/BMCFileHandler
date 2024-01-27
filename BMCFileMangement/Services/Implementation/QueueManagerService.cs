using BMCFileMangement.Models;
using BMCFileMangement.Services.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMCFileMangement.Services.Implementation
{
    public class QueueManagerService : IQueueManagerService
    {
        private List<FileHandlerEntity> queue = new List<FileHandlerEntity>();

        public void Enqueue(FileHandlerEntity item)
        {
            queue.Add(item);
        }

        /// <summary>
        /// Dequeue
        /// </summary>
        /// <returns></returns>
        public FileHandlerEntity? Dequeue()
        {
            if (queue.Count == 0)
            {
                return null; // or throw an exception
            }

            FileHandlerEntity item = queue[0];
            queue.RemoveAt(0);
            return item;
        }

        public void DisplayQueue()
        {
            Console.WriteLine("Queue contents:");
            foreach (var item in queue)
            {
                Console.WriteLine(item.filename);
            }
        }

        public string GetSuccessMessage()
        {
            return "Successful Operation!!";
        }

    }
}
