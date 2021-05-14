Namespace MotoreH2o.Oggetti
    <Serializable()> _
    Public Class OggettoScaglione
        Dim _id As Integer = 0
        Dim _idTipoUtenza As Integer = 0
        Dim _sDescrizioneTU As String = ""
        Dim _idEnte As String = ""
        Dim _da As Integer = 0
        Dim _a As Integer = 0
        Dim _anno As String = ""
        Dim _tariffa As Double = 0
        Dim _minimo As Double = 0
        Dim _aliquota As Double = 0

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
        Public Property dTariffa() As Double
            Get
                Return _tariffa
            End Get
            Set(ByVal Value As Double)
                _tariffa = Value
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
        Public Property dMinimo() As Double
            Get
                Return _minimo
            End Get
            Set(ByVal Value As Double)
                _minimo = Value
            End Set
        End Property
    End Class
End Namespace