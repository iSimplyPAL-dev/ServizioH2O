Namespace MotoreH2o.Oggetti
    <Serializable()> _
    Public Class ObjRicercaDoc
        Private _sEnte As String = ""
        Private _nFlusso As Integer = -1
        Private _nPeriodo As Integer = -1
        Private _sTipoDocumento As String = ""
        Private _sCognome As String = ""
        Private _sNome As String = ""
        Private _sCFPIva As String = ""
        Private _tDataDocumento As Date = DateTime.MaxValue
        Private _sNDocumento As String = ""
        Private _sMatricola As String = ""
        Private _sProvenienza As String = ""

        Public Property sEnte() As String
            Get
                Return _sEnte
            End Get
            Set(ByVal Value As String)
                _sEnte = Value
            End Set
        End Property
        Public Property nFlusso() As Integer
            Get
                Return _nFlusso
            End Get
            Set(ByVal Value As Integer)
                _nFlusso = Value
            End Set
        End Property
        Public Property nPeriodo() As Integer
            Get
                Return _nPeriodo
            End Get
            Set(ByVal Value As Integer)
                _nPeriodo = Value
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
        Public Property sCFPIva() As String
            Get
                Return _sCFPIva
            End Get
            Set(ByVal Value As String)
                _sCFPIva = Value
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
        Public Property sMatricola() As String
            Get
                Return _sMatricola
            End Get
            Set(ByVal Value As String)
                _sMatricola = Value
            End Set
        End Property
        Public Property sProvenienza() As String
            Get
                Return _sProvenienza
            End Get
            Set(ByVal Value As String)
                _sProvenienza = Value
            End Set
        End Property
    End Class
End Namespace
