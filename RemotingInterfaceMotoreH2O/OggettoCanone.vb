Namespace MotoreH2o.Oggetti
    <Serializable()> _
    Public Class OggettoCanone
        ''' <summary>
        ''' oggetto di definizione tariffa canone
        ''' </summary>
        ''' <remarks></remarks>
        Public Const Canone_Depurazione As Integer = 1
        Public Const Canone_Fognatura As Integer = 2
        Public Const Canone_H2O As Integer = 3

        Dim _id As Integer = 0
        Dim _idTipoUtenza As Integer = 0
        Dim _sDescrizioneTU As String = ""
        Dim _idTipoCanone As Integer = 0
        Dim _sDescrizioneTC As String = ""
        Dim _idEnte As String = ""
        Dim _anno As String = ""
        Dim _tariffa As Double = 0
        Dim _aliquota As Double = 0
        Dim _percentualeSuConsumo As Double = 0
        '*** 20141125 - Componente aggiuntiva sui consumi ***
        Dim _idServizio As Integer = Canone_H2O
        '*** ***

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
        Public Property idTipoCanone() As Integer
            Get
                Return _idTipoCanone
            End Get
            Set(ByVal Value As Integer)
                _idTipoCanone = Value
            End Set
        End Property
        Public Property sDescrizioneTC() As String
            Get
                Return _sDescrizioneTC
            End Get
            Set(ByVal Value As String)
                _sDescrizioneTC = Value
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
        Public Property dPercentualeSuConsumo() As Double
            Get
                Return _percentualeSuConsumo
            End Get
            Set(ByVal Value As Double)
                _percentualeSuConsumo = Value
            End Set
        End Property
        '*** 20141125 - Componente aggiuntiva sui consumi ***
        Public Property idServizio() As Integer
            Get
                Return _idServizio
            End Get
            Set(ByVal Value As Integer)
                _idServizio = Value
            End Set
        End Property
        '*** ***
    End Class
End Namespace