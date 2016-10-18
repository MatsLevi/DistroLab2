using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Database
{
    public class GetMessages
    {
        public static Message[] getMessages(string username)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    User user = (from User in db.Users where User.name == username select User).First();
                    System.Diagnostics.Debug.WriteLine("User id: " + user.userId + " name: " + user.name);
                    ReceivedMessage[] receivedMessages = (from ReceivedMessage in db.ReceivedMessages where ReceivedMessage.userId == user.userId select ReceivedMessage).ToArray();
                    System.Diagnostics.Debug.WriteLine("receivedMessages length: " + receivedMessages.Length);

                    Message[] messages = new Message[receivedMessages.Length];

                    for (int i = 0; i < receivedMessages.Length; i++)
                    {
                        foreach (Message msg in db.Messages.ToArray())
                        {
                            if (msg.messId == receivedMessages[i].messId)
                            {
                                messages[i] = msg;
                                System.Diagnostics.Debug.WriteLine("Message " + i + ": " + messages[i].message);
                            }
                        }
                    }

                    return messages;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to get all messages!");
                    return null;
                }
            }
        }
    }
}