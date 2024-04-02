using IronBarCode;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Notifications.Methods
{
    public class EmailServices
    {
        RpcClient client = new RpcClient();
        EventToNotification _event = new EventToNotification();
        public async Task<bool> SendEmail(string id, string EventID)
        {
            try
            {
            var particpinat = await  client.RequestMethod("Participant", id);
            Dictionary<string, string> part = JsonConvert.DeserializeObject<Dictionary<string, string>>(particpinat.ToString());
                var eventObject = await _event.RequestMethod("Event", EventID);
                if (eventObject != null)
                {
                    JObject jsonObject = JObject.Parse(eventObject.ToString());


                    var  eventDetails = jsonObject["Title"].ToString();
                        if (part != null && eventObject != null)
                        {
                            var receiverEmail = part["Email"];
                            string ParticipantName = part["FirstName"];
                            string EeventName = eventDetails;
                            string imagepath = GenerateQRCode(id+"#"+EventID);
                            string senderEmail = "omardriouch29@gmail.com";
                            string password = "passwordAPP";
                            SendEmail(senderEmail, receiverEmail, password, imagepath, EeventName, ParticipantName);


                        }
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
         public string GenerateQRCode(string id)
         {
            GeneratedBarcode barCode = QRCodeWriter.CreateQrCode(id, 200);
            string path = Path.Combine("D:\\Desktop\\MMCBackEnd\\BackEndMMC", "GeneratedQRCode");
            barCode.SetMargins(20);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filePath = Path.Combine(path, "QrCode.png");
            var isSaved = barCode.SaveAsPng(filePath);
            var fileName = Path.GetFileName(filePath);
            return filePath.ToString();
         }


        static void SendEmail(string senderEmail,  string receiverEmail, string password, string imagePath, string EventName, string ParticpantName)
        {
            try
            {
                string tempImagePath = Path.GetTempFileName();
                File.Copy(imagePath, tempImagePath, true);

                MailMessage mail = new MailMessage(new MailAddress(senderEmail, "MMCEvents"), new MailAddress(receiverEmail));
                mail.Subject = "Congratulations !! " + ParticpantName  + " and Welcome to "  + EventName ;
                 
                mail.IsBodyHtml = true;  

                 
             string htmlBody = @"
            
            <p>This email sent to you from MMC to confirm your participation</p>
            <p>Keep this QR code Private:</p>
            <img src='cid:qrcode'>";  
                
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");

                LinkedResource imageResource = new LinkedResource(tempImagePath);
                imageResource.ContentId = "qrcode";
                htmlView.LinkedResources.Add(imageResource);
                mail.AlternateViews.Add(htmlView);
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(senderEmail, password);
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(mail);

                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                        
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        
    }

     
}
