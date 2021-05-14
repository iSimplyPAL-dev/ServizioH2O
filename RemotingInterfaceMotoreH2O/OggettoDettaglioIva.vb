Namespace MotoreH2o.Oggetti
    <Serializable()> _
Public Class ObjDettaglioIva
        Private _IdDettaglioIva As Long = -1
        Private _nIdFatturaNota As Long = -1
        Private _sIdEnte As String = ""
        Private _sCapitolo As String = ""
        Private _sDescrizione As String = ""
        Private _nAliquota As Double = 0
        Private _impDettaglio As Double = 0
        Private _tDataInserimento As Date = Now
        Private _tDataVariazione As Date = DateTime.MaxValue
        Private _tDataCessazione As Date = DateTime.MaxValue
        Private _sOperatore As String = ""

        Public Property IdDettaglioIva() As Long
            Get
                Return _IdDettaglioIva
            End Get
            Set(ByVal Value As Long)
                _IdDettaglioIva = Value
            End Set
        End Property
        Public Property nIdFatturaNota() As Long
            Get
                Return _nIdFatturaNota
            End Get
            Set(ByVal Value As Long)
                _nIdFatturaNota = Value
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
        Public Property sCapitolo() As String
            Get
                Return _sCapitolo
            End Get
            Set(ByVal Value As String)
                _sCapitolo = Value
            End Set
        End Property
        Public Property sDescrizione() As String
            Get
                Return _sDescrizione
            End Get
            Set(ByVal Value As String)
                _sDescrizione = Value
            End Set
        End Property
        Public Property nAliquota() As Double
            Get
                Return _nAliquota
            End Get
            Set(ByVal Value As Double)
                _nAliquota = Value
            End Set
        End Property
        Public Property impDettaglio() As Double
            Get
                Return _impDettaglio
            End Get
            Set(ByVal Value As Double)
                _impDettaglio = Value
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
