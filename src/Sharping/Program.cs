using Sharping;

Console.WriteLine("Sharping!!!");

var url = "https://preapp.seg-social.pt/ws/gr/v1/gestaoFicheiro";

var user = "20017705043";
var pass = "39089294";

var body =
     @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ges=""http://app.seg-social.pt/ws/gr/gestaoficheiro"">
            <soapenv:Header></soapenv:Header>
            <soapenv:Body>
                <ges:consultarFicheiro>
                <Idficheiro>35830673</Idficheiro>
                </ges:consultarFicheiro>
            </soapenv:Body>
         </soapenv:Envelope>
        ";
try
{
    var conn = new SoapConnection(url, user, pass, body); 

    string content = await conn.PostRequest();

    Console.WriteLine(content);

    Console.WriteLine("Done!");
}
catch (Exception e) {
    Console.WriteLine(e.Message); 
}

Console.ReadLine();
