Namespace MotoreH2o.Oggetti
    <Serializable()> _
    Public Class OggettoDocumentiElaborati

        Private _nIdFlusso As Integer = -1
        Private _nIdContribuente As Integer = -1
        Private _sIdEnte As String = String.Empty
        Private _sNumeroFattura As String = String.Empty
        Private _tDataFattura As Date = DateTime.MaxValue
        Private _nIdModello As Integer = -1
        Private _sCampoOrdinamento As String = String.Empty
        Private _nNumeroProgressivo As Integer = -1
        Private _nNumeroFile As Integer = -1
        Private _bElaborato As Boolean = False
        Private _tDataEmissione As Date = DateTime.MaxValue

        Public Property IdFlusso() As Integer
            Get
                Return _nIdFlusso
            End Get
            Set(ByVal Value As Integer)
                _nIdFlusso = Value
            End Set
        End Property

        Public Property IdContribuente() As Integer
            Get
                Return _nIdContribuente
            End Get
            Set(ByVal Value As Integer)
                _nIdContribuente = Value
            End Set
        End Property

        Public Property IdEnte() As String
            Get
                Return _sIdEnte
            End Get
            Set(ByVal Value As String)
                _sIdEnte = Value
            End Set
        End Property

        Public Property NumeroFattura() As String
            Get
                Return _sNumeroFattura
            End Get
            Set(ByVal Value As String)
                _sNumeroFattura = Value
            End Set
        End Property

        Public Property DataFattura() As Date
            Get
                Return _tDataFattura
            End Get
            Set(ByVal Value As Date)
                _tDataFattura = Value
            End Set
        End Property

        Public Property IdModello() As Integer
            Get
                Return _nIdModello
            End Get
            Set(ByVal Value As Integer)
                _nIdModello = Value
            End Set
        End Property

        Public Property CampoOrdinamento() As String
            Get
                Return _sCampoOrdinamento
            End Get
            Set(ByVal Value As String)
                _sCampoOrdinamento = Value
            End Set
        End Property

        Public Property NumeroProgressivo() As Integer
            Get
                Return _nNumeroProgressivo
            End Get
            Set(ByVal Value As Integer)
                _nNumeroProgressivo = Value
            End Set
        End Property

        Public Property NumeroFile() As Integer
            Get
                Return _nNumeroFile
            End Get
            Set(ByVal Value As Integer)
                _nNumeroFile = Value
            End Set
        End Property

        Public Property Elaborato() As Boolean
            Get
                Return _bElaborato
            End Get
            Set(ByVal Value As Boolean)
                _bElaborato = Value
            End Set
        End Property

        Public Property DataEmissione() As Date
            Get
                Return _tDataEmissione
            End Get
            Set(ByVal Value As Date)
                _tDataEmissione = Value
            End Set
        End Property
    End Class

End Namespace
