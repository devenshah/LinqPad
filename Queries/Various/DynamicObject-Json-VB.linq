<Query Kind="VBProgram">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
</Query>

Sub Main
	dim str = "{""CertificateUrl"":null,""Rrn"":""8903-7944-5229-7926-3753""}"
	
	dim res = JsonConvert.DeserializeObject(of ECMKGetCertificateResponse )(str)
	
	res.Dump()
	
End Sub

Public Class ECMKGetCertificateResponse 

	Private mCertificateUrl As String = ""
    Private mRrn As String = ""
    Private mPdfData() As Byte
    Private mHasError As Boolean
    Private mErrorMessage As String = ""

    Public Property CertificateUrl() As String
        Get
            Return mCertificateUrl
        End Get
        Set(ByVal value As String)
            mCertificateUrl = value
        End Set
    End Property

    Public Property Rrn() As String
        Get
            Return mRrn
        End Get
        Set(ByVal value As String)
            mRrn = value
        End Set
    End Property

    'Public Property PdfData() As Byte()
    '    Get
    '        Return mPdfData
    '    End Get
    '    Friend Set(ByVal value As Byte())
    '        mPdfData = value
    '    End Set
    'End Property
    Public Property HasError() As Boolean
        Get
            Return mHasError
        End Get
        Set(ByVal value As Boolean)
            mRrn = mHasError
        End Set
    End Property
    Public Property ErrorMessage() As String
        Get
            Return mErrorMessage
        End Get
        Set(ByVal value As String)
            mErrorMessage = value
        End Set
    End Property

    Public Sub New()

    End Sub

    
End Class
