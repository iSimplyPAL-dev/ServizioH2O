Namespace MotoreH2o.Oggetti
    <Serializable()> _
    Public Class OggettoQuotaFissa
        Dim _id As Integer = 0
        Dim _idEnte As String = ""
        Dim _idTipoUtenza As Integer = 0
        Dim _sDescrizioneTU As String = ""
        Dim _da As Integer = 0
        Dim _a As Integer = 0
        Dim _anno As String = ""
        Dim _tipoCanone As String = ""
        Dim _importoH2O As Double = 0
        Dim _importoDep As Double = 0
        Dim _importoFog As Double = 0
        Dim _aliquota As Double = 0
        Dim _bIsAGiorni As Boolean = False

        Public Property ID() As Integer
            Get
                Return _id
            End Get
            Set(ByVal Value As Integer)
                _id = Value
            End Set
        End Property
        Public Property idTipoUtenza() As Integer
            Get
                Return _idTipoUtenza
            End Get
            Set(ByVal Value As Integer)
                _idTipoUtenza = Value
            End Set
        End Property
        Public Property sDescrizioneTU() As String
            Get
                Return _sDescrizioneTU
            End Get
            Set(ByVal Value As String)
                _sDescrizioneTU = Value
            End Set
        End Property
        Public Property DA() As Integer
            Get
                Return _da
            End Get
            Set(ByVal Value As Integer)
                _da = Value
            End Set
        End Property
        Public Property A() As Integer
            Get
                Return _a
            End Get
            Set(ByVal Value As Integer)
                _a = Value
            End Set
        End Property
        Public Property sIdEnte() As String
            Get
                Return _idEnte
            End Get
            Set(ByVal Value As String)
                _idEnte = Value
            End Set
        End Property
        Public Property sAnno() As String
            Get
                Return _anno
            End Get
            Set(ByVal Value As String)
                _anno = Value
            End Set
        End Property
        Public Property TipoCanone() As String
            Get
                Return _tipoCanone
            End Get
            Set(ByVal Value As String)
                _tipoCanone = Value
            End Set
        End Property
        Public Property dImportoH2O() As Double
            Get
                Return _importoH2O
            End Get
            Set(ByVal Value As Double)
                _importoH2O = Value
            End Set
        End Property
        Public Property dImportoDep() As Double
            Get
                Return _importoDep
            End Get
            Set(ByVal Value As Double)
                _importoDep = Value
            End Set
        End Property
        Public Property dImportoFog() As Double
            Get
                Return _importoFog
            End Get
            Set(ByVal Value As Double)
                _importoFog = Value
            End Set
        End Property
        Public Property dAliquota() As Double
            Get
                Return _aliquota
            End Get
            Set(ByVal Value As Double)
                _aliquota = Value
            End Set
        End Property
        Public Property bIsAGiorni() As Boolean
            Get
                Return _bIsAGiorni
            End Get
            Set(ByVal Value As Boolean)
                _bIsAGiorni = Value
            End Set
        End Property
    End Class
End Namespace