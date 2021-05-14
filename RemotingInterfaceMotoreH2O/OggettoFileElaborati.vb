Namespace MotoreH2o.Oggetti
    <Serializable()> _
Public Class OggettoFileElaborati
        Private _nId As Integer = -1
        Private _nIdFile As Integer = -1
        Private _sIdEnte As String = String.Empty
        Private _nIdRuolo As Integer = -1
        Private _sNomeFile As String = String.Empty
        Private _sPath As String = String.Empty
        Private _sPathWeb As String = String.Empty
        Private _sDataElaborazione As Date = DateTime.MaxValue

        Public Property Id() As Integer
            Get
                Return _nId
            End Get
            Set(ByVal Value As Integer)
                _nId = Value
            End Set
        End Property

        Public Property IdFile() As Integer
            Get
                Return _nIdFile
            End Get
            Set(ByVal Value As Integer)
                _nIdFile = Value
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

        Public Property IdRuolo() As Integer
            Get
                Return _nIdRuolo
            End Get
            Set(ByVal Value As Integer)
                _nIdRuolo = Value
            End Set
        End Property

        Public Property NomeFile() As String
            Get
                Return _sNomeFile
            End Get
            Set(ByVal Value As String)
                _sNomeFile = Value
            End Set
        End Property

        Public Property Path() As String
            Get
                Return _sPath
            End Get
            Set(ByVal Value As String)
                _sPath = Value
            End Set
        End Property

        Public Property PathWeb() As String
            Get
                Return _sPathWeb
            End Get
            Set(ByVal Value As String)
                _sPathWeb = Value
            End Set
        End Property

        Public Property DataElaborazione() As Date
            Get
                Return _sDataElaborazione
            End Get
            Set(ByVal Value As Date)
                _sDataElaborazione = Value
            End Set
        End Property
    End Class
End Namespace


