
Imports System.Net
Imports System.Text

Module ModuleWhatsAppApi
    Sub Main()
        Dim WebRequest As HttpWebRequest
        Dim instance_id As String = "instance95126"
        Dim token As String = "n6orpwqgb6dp0ukd"
        Dim mobile_number As String = "00962791908159"
        Dim ultramsgApiUrl As String = "https://api.ultramsg.com/" + instance_id + "/messages/chat"

        WebRequest = CType(HttpWebRequest.Create(ultramsgApiUrl), HttpWebRequest)
        Dim postdata As String = "token=" + token + "&to=" + mobile_number + "&body=WhatsApp API on UltraMsg.com works good"
        Dim postdatabytes As Byte() = New UTF8Encoding().GetBytes(postdata)

        WebRequest.Method = "POST"
        WebRequest.ContentType = "application/x-www-form-urlencoded"
        'WebRequest.GetRequestStream().Write(postdatabytes)
        WebRequest.GetRequestStream().Write(postdatabytes, 0, postdatabytes.Length)
<<<<<<< HEAD
        Dim ret As New IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
=======
        Dim ret As New System.IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Console.WriteLine(ret.ReadToEnd())
    End Sub

    'https://api.ultramsg.com/instance95126/
    Sub MainTemplate()
        Dim WebRequest As HttpWebRequest
        WebRequest = CType(HttpWebRequest.Create("https://api.alvochat.com/instance95126/messages/template"), HttpWebRequest)
        Dim postdata As String = "token=n6orpwqgb6dp0ukd&to=mobile_number&name=hello_world&language=en_us&header=&body=&buttons=&priority="
<<<<<<< HEAD
        Dim enc As New UTF8Encoding()
=======
        Dim enc As New System.Text.UTF8Encoding()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim postdatabytes As Byte() = enc.GetBytes(postdata)
        WebRequest.Method = "POST"
        WebRequest.ContentType = "application/x-www-form-urlencoded"
        'WebRequest.GetRequestStream().Write(postdatabytes)
        WebRequest.GetRequestStream().Write(postdatabytes, 0, postdatabytes.Length)
<<<<<<< HEAD
        Dim ret As New IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
=======
        Dim ret As New System.IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Console.WriteLine(ret.ReadToEnd())
    End Sub

    Sub MainChat()
        Dim WebRequest As HttpWebRequest
        WebRequest = CType(HttpWebRequest.Create("https://api.alvochat.com/instance95126/messages/chat"), HttpWebRequest)
        Dim postdata As String = "token=n6orpwqgb6dp0ukd&to=mobile_number&body=WhatsApp API on alvochat.com works good&priority=&preview_url=&message_id="
<<<<<<< HEAD
        Dim enc As New UTF8Encoding()
=======
        Dim enc As New System.Text.UTF8Encoding()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim postdatabytes As Byte() = enc.GetBytes(postdata)
        WebRequest.Method = "POST"
        WebRequest.ContentType = "application/x-www-form-urlencoded"
        'WebRequest.GetRequestStream().Write(postdatabytes)
        WebRequest.GetRequestStream().Write(postdatabytes, 0, postdatabytes.Length)
<<<<<<< HEAD
        Dim ret As New IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
=======
        Dim ret As New System.IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Console.WriteLine(ret.ReadToEnd())
    End Sub
    Sub MainImage()
        Dim WebRequest As HttpWebRequest
        WebRequest = CType(HttpWebRequest.Create("https://api.alvochat.com/instance95126/messages/image"), HttpWebRequest)
        Dim postdata As String = "token=n6orpwqgb6dp0ukd&to=mobile_number&image=https://alvochat-example.s3-accelerate.amazonaws.com/image/1.jpeg&caption=image caption&priority=&message_id="
<<<<<<< HEAD
        Dim enc As New UTF8Encoding()
=======
        Dim enc As New System.Text.UTF8Encoding()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim postdatabytes As Byte() = enc.GetBytes(postdata)
        WebRequest.Method = "POST"
        WebRequest.ContentType = "application/x-www-form-urlencoded"
        'WebRequest.GetRequestStream().Write(postdatabytes)
        WebRequest.GetRequestStream().Write(postdatabytes, 0, postdatabytes.Length)
<<<<<<< HEAD
        Dim ret As New IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
=======
        Dim ret As New System.IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Console.WriteLine(ret.ReadToEnd())
    End Sub
    Sub MainAudio()
        Dim WebRequest As HttpWebRequest
        WebRequest = CType(HttpWebRequest.Create("https://api.alvochat.com/instance95126/messages/audio"), HttpWebRequest)
        Dim postdata As String = "token=n6orpwqgb6dp0ukd&to=mobile_number&audio=https://alvochat-example.s3-accelerate.amazonaws.com/audio/1.mp3&priority=&message_id="
<<<<<<< HEAD
        Dim enc As New UTF8Encoding()
=======
        Dim enc As New System.Text.UTF8Encoding()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim postdatabytes As Byte() = enc.GetBytes(postdata)
        WebRequest.Method = "POST"
        WebRequest.ContentType = "application/x-www-form-urlencoded"
        'WebRequest.GetRequestStream().Write(postdatabytes)
        WebRequest.GetRequestStream().Write(postdatabytes, 0, postdatabytes.Length)
<<<<<<< HEAD
        Dim ret As New IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
=======
        Dim ret As New System.IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Console.WriteLine(ret.ReadToEnd())
    End Sub
    Sub MainVideo()
        Dim WebRequest As HttpWebRequest
        WebRequest = CType(HttpWebRequest.Create("https://api.alvochat.com/instance95126/messages/video"), HttpWebRequest)
        Dim postdata As String = "token=n6orpwqgb6dp0ukd&to=mobile_number&video=https://alvochat-example.s3-accelerate.amazonaws.com/video/1.mp4&caption=video caption&priority=&message_id="
<<<<<<< HEAD
        Dim enc As New UTF8Encoding()
=======
        Dim enc As New System.Text.UTF8Encoding()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim postdatabytes As Byte() = enc.GetBytes(postdata)
        WebRequest.Method = "POST"
        WebRequest.ContentType = "application/x-www-form-urlencoded"
        'WebRequest.GetRequestStream().Write(postdatabytes)
        WebRequest.GetRequestStream().Write(postdatabytes, 0, postdatabytes.Length)
<<<<<<< HEAD
        Dim ret As New IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
=======
        Dim ret As New System.IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Console.WriteLine(ret.ReadToEnd())
    End Sub
    Sub MainDocument()
        Dim WebRequest As HttpWebRequest
        WebRequest = CType(HttpWebRequest.Create("https://api.alvochat.com/instance95126/messages/document"), HttpWebRequest)
        Dim postdata As String = "token=n6orpwqgb6dp0ukd&to=mobile_number&document=https://alvochat-example.s3-accelerate.amazonaws.com/document/1.pdf&filename=&priority=&message_id="
<<<<<<< HEAD
        Dim enc As New UTF8Encoding()
=======
        Dim enc As New System.Text.UTF8Encoding()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim postdatabytes As Byte() = enc.GetBytes(postdata)
        WebRequest.Method = "POST"
        WebRequest.ContentType = "application/x-www-form-urlencoded"
        'WebRequest.GetRequestStream().Write(postdatabytes)
        WebRequest.GetRequestStream().Write(postdatabytes, 0, postdatabytes.Length)
<<<<<<< HEAD
        Dim ret As New IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
=======
        Dim ret As New System.IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Console.WriteLine(ret.ReadToEnd())
    End Sub
    Sub MainSticker()
        Dim WebRequest As HttpWebRequest
        WebRequest = CType(HttpWebRequest.Create("https://api.alvochat.com/instance95126/messages/sticker"), HttpWebRequest)
        Dim postdata As String = "token=n6orpwqgb6dp0ukd&to=mobile_number&sticker=https://alvochat-example.s3-accelerate.amazonaws.com/sticker/1.webp&priority=&message_id="
<<<<<<< HEAD
        Dim enc As New UTF8Encoding()
=======
        Dim enc As New System.Text.UTF8Encoding()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim postdatabytes As Byte() = enc.GetBytes(postdata)
        WebRequest.Method = "POST"
        WebRequest.ContentType = "application/x-www-form-urlencoded"
        'WebRequest.GetRequestStream().Write(postdatabytes)
        WebRequest.GetRequestStream().Write(postdatabytes, 0, postdatabytes.Length)
<<<<<<< HEAD
        Dim ret As New IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
=======
        Dim ret As New System.IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Console.WriteLine(ret.ReadToEnd())
    End Sub

    Sub MainContact()
        Dim WebRequest As HttpWebRequest
        WebRequest = CType(HttpWebRequest.Create("https://api.alvochat.com/instance95126/messages/contact"), HttpWebRequest)
        Dim postdata As String = "token=n6orpwqgb6dp0ukd&to=mobile_number&contact=&priority=&message_id="
<<<<<<< HEAD
        Dim enc As New UTF8Encoding()
=======
        Dim enc As New System.Text.UTF8Encoding()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim postdatabytes As Byte() = enc.GetBytes(postdata)
        WebRequest.Method = "POST"
        WebRequest.ContentType = "application/x-www-form-urlencoded"
        'WebRequest.GetRequestStream().Write(postdatabytes)
        WebRequest.GetRequestStream().Write(postdatabytes, 0, postdatabytes.Length)
<<<<<<< HEAD
        Dim ret As New IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
=======
        Dim ret As New System.IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Console.WriteLine(ret.ReadToEnd())
    End Sub

    Sub MainList()
        Dim WebRequest As HttpWebRequest
        WebRequest = CType(HttpWebRequest.Create("https://api.alvochat.com/instance95126/messages/list"), HttpWebRequest)
        Dim postdata As String = "token=n6orpwqgb6dp0ukd&to=mobile_number&header=header&body= please select one of the following options&footer=footer&button=options§ions=option_1,option_2,option_3&priority=&message_id="
<<<<<<< HEAD
        Dim enc As New UTF8Encoding()
=======
        Dim enc As New System.Text.UTF8Encoding()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim postdatabytes As Byte() = enc.GetBytes(postdata)
        WebRequest.Method = "POST"
        WebRequest.ContentType = "application/x-www-form-urlencoded"
        'WebRequest.GetRequestStream().Write(postdatabytes)
        WebRequest.GetRequestStream().Write(postdatabytes, 0, postdatabytes.Length)
<<<<<<< HEAD
        Dim ret As New IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
=======
        Dim ret As New System.IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Console.WriteLine(ret.ReadToEnd())
    End Sub
    Sub MainProduct()
        Dim WebRequest As HttpWebRequest
        WebRequest = CType(HttpWebRequest.Create("https://api.alvochat.com/instance95126/messages/product"), HttpWebRequest)
        Dim postdata As String = "token=n6orpwqgb6dp0ukd&to=mobile_number&header=header&body=Hi , check out our new products&footer=footer&catalog_id=&product=&priority=&message_id="
<<<<<<< HEAD
        Dim enc As New UTF8Encoding()
=======
        Dim enc As New System.Text.UTF8Encoding()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim postdatabytes As Byte() = enc.GetBytes(postdata)
        WebRequest.Method = "POST"
        WebRequest.ContentType = "application/x-www-form-urlencoded"
        'WebRequest.GetRequestStream().Write(postdatabytes)
        WebRequest.GetRequestStream().Write(postdatabytes, 0, postdatabytes.Length)
<<<<<<< HEAD
        Dim ret As New IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
=======
        Dim ret As New System.IO.StreamReader(WebRequest.GetResponse().GetResponseStream())
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Console.WriteLine(ret.ReadToEnd())
    End Sub
End Module


