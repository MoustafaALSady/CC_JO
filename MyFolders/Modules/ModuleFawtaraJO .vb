Imports System.Net.Http
Imports System.Threading.Tasks



Module ModuleFawtaraJO
    Public CLIENT_ID As Integer
    Public Secret_key As String
    Public TypeInvoice As String
    Public New_cash As String
    Public Vat_id As String

    Public Invoice_id As Integer
    Public DateInvoice As Date
    Public Company_name As String

    Public Customer_id As Integer
    Public Customer_name As String
    Public Customer_phone As Integer
    Public Seller_id As Integer

    Public Discount As Double
    Public TaxExclusiveAmount As Double
    Public TaxInclusiveAmount As Double
    Public AllowanceTotalAmount As Double

    Public PayableAmount As Double
    Public Priceinvoice As Double



    Class ProgramFawtaraJO
        Private Shared Async Function FawtaraJO() As Task
            Dim Client As New HttpClient()
            Dim url = "http://fawtara.link/api?client_id=YOUR_CLIENT_ID&secret_key=YOUR_SECRET_CODE&type=new_cash&invoice_id=12345&date=2024-10-23¬es=Some%20Notes&vat_id=YOUR_VAT_ID&company_name=Fawtara%20Link%20Co.&customer_name=Mojeer%20Salman&customer_id=9080706050&customer_phone=0770000000&seller_id=YOUR_SELLER_ID&discount=0&TaxExclusiveAmount=172&TaxInclusiveAmount=170&AllowanceTotalAmount=2&PayableAmount=170&item[0][name]=Test%20Item&item[0][price]=4&item[0][qty]=43&item[0][discount]=2"

            'url = "http://fawtara.link/api?client_id=CLIENT_ID&secret_key=Secret_key&type=New_cash&invoice_id=Invoice_id&date=DateInvoice¬es=Some%20Notes&vat_id=Vat_id&company_name=Company_name%20Link%20Co.&customer_name=customer_name%20Salman&customer_id=Customer_id&customer_phone=Customer_phone&seller_id=Seller_id&discount=Discount&TaxExclusiveAmount=TaxExclusiveAmount&TaxInclusiveAmount=TaxInclusiveAmount&AllowanceTotalAmount=AllowanceTotalAmount&PayableAmount=PayableAmount&item[0][name]=Test%20Item&item[0][price]=Priceinvoice&item[0][qty]=43&item[0][discount]=discount"
            Dim response = Await Client.GetStringAsync(url)
            Console.WriteLine(response)
        End Function
    End Class


End Module
