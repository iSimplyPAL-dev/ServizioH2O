Namespace MotoreH2o.Oggetti
    <Serializable()> _
    Public Class OggettoNoloContatore
        Dim _id As Integer = 0
        Dim _idTipoContatore As Integer = 0
        Dim _sDescrizioneTContatore As String = ""
        Dim _idEnte As String = ""
        Dim _anno As String = ""
        Dim _importo As Double = 0
        Dim _aliquota As Double = 0
        Dim _bIsUnaTantum As Boolean = False

        Public Property ID() As Integer
            Get
                Return _id
            End Get
            Set(ByVal Value As Integer)
                _id = Value
            End Set
        End Property
        Public Property idTipoContatore() As Integer
            Get
                Return _idTipoContatore
            End Get
            Set(ByVal Value As Integer)
                _idTipoContatore = Value
            End Set
        End Property
        Public Property sDescrizioneTContatore() As String
            Get
                Return _sDescrizioneTContatore
            End Get
            Set(ByVal Value As String)
                _sDescrizioneTContatore = Value
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

        Public Property dImporto() As Double
            Get
                Return _importo
            End Get
            Set(ByVal Value As Double)
                _importo = Value
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
        Public Property bIsUnaTantum() As Boolean
            Get
                Return _bIsUnaTantum
            End Get
            Set(ByVal Value As Boolean)
                _bIsUnaTantum = Value
            End Set
        End Property
    End Class
End Namespace