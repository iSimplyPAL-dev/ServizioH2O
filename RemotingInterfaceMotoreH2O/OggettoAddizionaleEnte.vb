Namespace MotoreH2o.Oggetti
    <Serializable()> _
    Public Class OggettoAddizionaleEnte

        Dim _id As Integer = 0
        Dim _idAddizionale As Integer = 0
        Dim _descrizione As String = ""
        Dim _anno As String = ""
        Dim _idEnte As String = ""
        Dim _importo As Double = 0
        Dim _aliquota As Double = 0

        Public Property ID() As Integer
            Get
                Return _id
            End Get
            Set(ByVal Value As Integer)
                _id = Value
            End Set
        End Property
        Public Property IDaddizionale() As Integer
            Get
                Return _idAddizionale
            End Get
            Set(ByVal Value As Integer)
                _idAddizionale = Value
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

        Public Property sDescrizione() As String
            Get
                Return _descrizione
            End Get
            Set(ByVal Value As String)
                _descrizione = Value
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

        Public Property Aliquota() As Double
            Get
                Return _aliquota
            End Get
            Set(ByVal Value As Double)
                _aliquota = Value
            End Set
        End Property

    End Class
End Namespace