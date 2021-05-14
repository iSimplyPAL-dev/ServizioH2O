Namespace MotoreH2o.Oggetti
    <Serializable()> _
Public Class ObjTotRuoloFatture
        Public Sub New()
        End Sub

        Private _IdFlusso As Integer = -1
        Private _sIdEnte As String = ""
        Private _nIdPeriodo As Integer = -1
        Private _tDataCalcoli As Date = DateTime.MaxValue
        Private _nNContribuenti As Integer = 0
        Private _nNDocumenti As Integer = 0
        Private _nFirstNDoc As Integer = 0
        Private _nLastNDoc As Integer = 0
        Private _impPositivi As Double = 0
        Private _impNegativi As Double = 0
        Private _tDataStampaMinuta As Date = DateTime.MaxValue
        Private _tDataOkMinuta As Date = DateTime.MaxValue
        Private _tDataNumerazione As Date = DateTime.MaxValue
        Private _tDataEmissioneFattura As Date = DateTime.MaxValue
        Private _tDataScadenza As Date = DateTime.MaxValue
        Private _sNote As String = ""
        Private _sOperatore As String = ""
        Private _oFatture() As ObjFattura = Nothing
        Private _tDataApprovazioneDOC As Date = DateTime.MaxValue

        Public Property IdFlusso() As Integer
            Get
                Return _IdFlusso
            End Get
            Set(ByVal Value As Integer)
                _IdFlusso = Value
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
        Public Property nIdPeriodo() As Integer
            Get
                Return _nIdPeriodo
            End Get
            Set(ByVal Value As Integer)
                _nIdPeriodo = Value
            End Set
        End Property
        Public Property tDataCalcoli() As Date
            Get
                Return _tDataCalcoli
            End Get
            Set(ByVal Value As Date)
                _tDataCalcoli = Value
            End Set
        End Property
        Public Property nNContribuenti() As Integer
            Get
                Return _nNContribuenti
            End Get
            Set(ByVal Value As Integer)
                _nNContribuenti = Value
            End Set
        End Property
        Public Property nNDocumenti() As Integer
            Get
                Return _nNDocumenti
            End Get
            Set(ByVal Value As Integer)
                _nNDocumenti = Value
            End Set
        End Property
        Public Property nFirstNDoc() As Integer
            Get
                Return _nFirstNDoc
            End Get
            Set(ByVal Value As Integer)
                _nFirstNDoc = Value
            End Set
        End Property
        Public Property nLastNDoc() As Integer
            Get
                Return _nLastNDoc
            End Get
            Set(ByVal Value As Integer)
                _nLastNDoc = Value
            End Set
        End Property
        Public Property impPositivi() As Double
            Get
                Return _impPositivi
            End Get
            Set(ByVal Value As Double)
                _impPositivi = Value
            End Set
        End Property
        Public Property impNegativi() As Double
            Get
                Return _impNegativi
            End Get
            Set(ByVal Value As Double)
                _impNegativi = Value
            End Set
        End Property
        Public Property tDataStampaMinuta() As Date
            Get
                Return _tDataStampaMinuta
            End Get
            Set(ByVal Value As Date)
                _tDataStampaMinuta = Value
            End Set
        End Property
        Public Property tDataOkMinuta() As Date
            Get
                Return _tDataOkMinuta
            End Get
            Set(ByVal Value As Date)
                _tDataOkMinuta = Value
            End Set
        End Property
        Public Property tDataNumerazione() As Date
            Get
                Return _tDataNumerazione
            End Get
            Set(ByVal Value As Date)
                _tDataNumerazione = Value
            End Set
        End Property
        Public Property tDataEmissioneFattura() As Date
            Get
                Return _tDataEmissioneFattura
            End Get
            Set(ByVal Value As Date)
                _tDataEmissioneFattura = Value
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
        Public Property sNote() As String
            Get
                Return _sNote
            End Get
            Set(ByVal Value As String)
                _sNote = Value
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
        Public Property oFatture() As ObjFattura()
            Get
                Return _oFatture
            End Get
            Set(ByVal Value As ObjFattura())
                _oFatture = Value
            End Set
        End Property
        Public Property tDataApprovazioneDOC() As Date
            Get
                Return _tDataApprovazioneDOC
            End Get
            Set(ByVal Value As Date)
                _tDataApprovazioneDOC = Value
            End Set
        End Property
    End Class
End Namespace
