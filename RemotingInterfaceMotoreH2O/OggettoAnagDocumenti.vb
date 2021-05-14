Namespace MotoreH2o.Oggetti
    <Serializable()> _
Public Class ObjAnagDocumenti
        Private _nIdDocumento As Integer = -1
        Private _sPeriodo As String = ""
        Private _sCognome As String = ""
        Private _sNome As String = ""
        Private _sCodFiscalePIva As String = ""
        Private _sMatricola As String = ""
        Private _sTipoDocumento As String = ""
        Private _tDataDocumento As Date = DateTime.MaxValue
        Private _sNDocumento As String = ""
        Private _impDocumento As Double = 0
        Private _sVariato As String = ""
        Private _bSelezionato As Boolean = False

        Public Property nIdDocumento() As Integer
            Get
                Return _nIdDocumento
            End Get
            Set(ByVal Value As Integer)
                _nIdDocumento = Value
            End Set
        End Property
        Public Property sPeriodo() As String
            Get
                Return _sPeriodo
            End Get
            Set(ByVal Value As String)
                _sPeriodo = Value
            End Set
        End Property
        Public Property sCognome() As String
            Get
                Return _sCognome
            End Get
            Set(ByVal Value As String)
                _sCognome = Value
            End Set
        End Property
        Public Property sNome() As String
            Get
                Return _sNome
            End Get
            Set(ByVal Value As String)
                _sNome = Value
            End Set
        End Property
        Public Property sCodFiscalePIva() As String
            Get
                Return _sCodFiscalePIva
            End Get
            Set(ByVal Value As String)
                _sCodFiscalePIva = Value
            End Set
        End Property
        Public Property sMatricola() As String
            Get
                Return _sMatricola
            End Get
            Set(ByVal Value As String)
                _sMatricola = Value
            End Set
        End Property
        Public Property sTipoDocumento() As String
            Get
                Return _sTipoDocumento
            End Get
            Set(ByVal Value As String)
                _sTipoDocumento = Value
            End Set
        End Property
        Public Property tDataDocumento() As Date
            Get
                Return _tDataDocumento
            End Get
            Set(ByVal Value As Date)
                _tDataDocumento = Value
            End Set
        End Property
        Public Property sNDocumento() As String
            Get
                Return _sNDocumento
            End Get
            Set(ByVal Value As String)
                _sNDocumento = Value
            End Set
        End Property
        Public Property impDocumento() As Double
            Get
                Return _impDocumento
            End Get
            Set(ByVal Value As Double)
                _impDocumento = Value
            End Set
        End Property
        Public Property sVariato() As String
            Get
                Return _sVariato
            End Get
            Set(ByVal Value As String)
                _sVariato = Value
            End Set
        End Property
        Public Property Selezionato() As Boolean
            Get
                Return _bSelezionato
            End Get
            Set(ByVal Value As Boolean)
                _bSelezionato = Value
            End Set
        End Property

    End Class
End Namespace
