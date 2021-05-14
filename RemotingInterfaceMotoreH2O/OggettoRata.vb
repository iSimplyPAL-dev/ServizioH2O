Namespace MotoreH2o.Oggetti
    <Serializable()> _
    Public Class ObjConfiguraRata
        Private _Id As Integer = -1
        Private _nIdRuolo As Integer = -1
        Private _sIdEnte As String = ""
        Private _sNRata As String = ""
        Private _sDescrRata As String = ""
        Private _tDataScadenza As Date = DateTime.MaxValue

        Public Property Id() As Integer
            Get
                Return _Id
            End Get
            Set(ByVal Value As Integer)
                _Id = Value
            End Set
        End Property
        Public Property nIdRuolo() As Integer
            Get
                Return _nIdRuolo
            End Get
            Set(ByVal Value As Integer)
                _nIdRuolo = Value
            End Set
        End Property
        Public Property sIdEnte() As String
            Get
                Return _sIdEnte
            End Get
            Set(ByVal Value As String)
                _sIdEnte = Value
            End Set
        End Property
        Public Property sNRata() As String
            Get
                Return _sNRata
            End Get
            Set(ByVal Value As String)
                _sNRata = Value
            End Set
        End Property
        Public Property sDescrRata() As String
            Get
                Return _sDescrRata
            End Get
            Set(ByVal Value As String)
                _sDescrRata = Value
            End Set
        End Property
        Public Property tDataScadenza() As Date
            Get
                Return _tDataScadenza
            End Get
            Set(ByVal Value As Date)
                _tDataScadenza = Value
            End Set
        End Property

        Public Sub New()
            Id = -1
            nidruolo = -1
            sIdEnte = ""
            sNRata = ""
            sDescrRata = ""
            tDataScadenza = DateTime.MaxValue
        End Sub
    End Class

    <Serializable()> _
    Public Class ObjRata
        Public Sub New()
        End Sub

        Private _Id As Integer = -1
        Private _nIdFattura As Integer = -1
        Private _sIdEnte As String = ""
        Private _tDataDocumento As Date = DateTime.MaxValue
        Private _sNDocumento As String = ""
        Private _nIdUtente As Integer = -1
        Private _sNRata As String = ""
        Private _sDescrRata As String = ""
        Private _impRata As Double = 0
        Private _tDataScadenza As Date = DateTime.MaxValue
        Private _sCodBollettino As String = ""
        Private _sCodeline As String = ""
        Private _sContoCorrente As String = ""
        Private _tDataInserimento As date=now
        Private _tDataVariazione As Date = DateTime.MaxValue
        Private _tDataCessazione As Date = DateTime.MaxValue
        Private _sOperatore As String = ""

        Public Property Id() As Integer
            Get
                Return _Id
            End Get
            Set(ByVal Value As Integer)
                _Id = Value
            End Set
        End Property
        Public Property sIdEnte() As String
            Get
                Return _sIdEnte
            End Get
            Set(ByVal Value As String)
                _sIdEnte = Value
            End Set
        End Property
        Public Property nIdFattura() As Integer
            Get
                Return _nIdFattura
            End Get
            Set(ByVal Value As Integer)
                _nIdFattura = Value
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
        Public Property nIdUtente() As Integer
            Get
                Return _nIdUtente
            End Get
            Set(ByVal Value As Integer)
                _nIdUtente = Value
            End Set
        End Property
        Public Property sNRata() As String
            Get
                Return _sNRata
            End Get
            Set(ByVal Value As String)
                _sNRata = Value
            End Set
        End Property
        Public Property sDescrRata() As String
            Get
                Return _sDescrRata
            End Get
            Set(ByVal Value As String)
                _sDescrRata = Value
            End Set
        End Property
        Public Property impRata() As Double
            Get
                Return _impRata
            End Get
            Set(ByVal Value As Double)
                _impRata = Value
            End Set
        End Property
        Public Property tDataScadenza() As Date
            Get
                Return _tDataScadenza
            End Get
            Set(ByVal Value As Date)
                _tDataScadenza = Value
            End Set
        End Property
        Public Property sCodBollettino() As String
            Get
                Return _sCodBollettino
            End Get
            Set(ByVal Value As String)
                _sCodBollettino = Value
            End Set
        End Property
        Public Property sCodeline() As String
            Get
                Return _sCodeline
            End Get
            Set(ByVal Value As String)
                _sCodeline = Value
            End Set
        End Property
        Public Property sContoCorrente() As String
            Get
                Return _sContoCorrente
            End Get
            Set(ByVal Value As String)
                _sContoCorrente = Value
            End Set
        End Property
        Public Property tDataInserimento() As Date
            Get
                Return _tDataInserimento
            End Get
            Set(ByVal Value As Date)
                _tDataInserimento = Value
            End Set
        End Property
        Public Property tDataVariazione() As Date
            Get
                Return _tDataVariazione
            End Get
            Set(ByVal Value As Date)
                _tDataVariazione = Value
            End Set
        End Property
        Public Property tDataCessazione() As Date
            Get
                Return _tDataCessazione
            End Get
            Set(ByVal Value As Date)
                _tDataCessazione = Value
            End Set
        End Property
        Public Property sOperatore() As String
            Get
                Return _sOperatore
            End Get
            Set(ByVal Value As String)
                _sOperatore = Value
            End Set
        End Property
    End Class
End Namespace
