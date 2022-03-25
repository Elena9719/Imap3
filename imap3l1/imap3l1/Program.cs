using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using Limilabs.Client.IMAP;
using Limilabs.Mail;

namespace imap3l1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Imap imap = new Imap())
            {
                imap.ConnectSSL("imap.gmail.com");  // or ConnectSSL for SSL
                imap.UseBestLogin("djdkdjfjf@gmail.com", "password"); //add password and email
                imap.SelectInbox();
                List<long> uids = imap.Search(Flag.Unseen);
                foreach (long uid in uids)
                {
                    IMail email = new MailBuilder()
                        .CreateFromEml(imap.GetMessageByUID(uid));
                    Console.WriteLine(email.Subject);
                }
                imap.Close();
            }

        }
    }
}
