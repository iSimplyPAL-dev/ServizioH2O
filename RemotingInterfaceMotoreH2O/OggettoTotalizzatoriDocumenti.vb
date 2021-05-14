Namespace MotoreH2o.Oggetti
    <Serializable()> _
Public Class ObjTotalizzatoriDocumenti
        Private _nContribuenti As Integer = -1
        Private _nFatture As Integer = -1
        Private _nNote As Integer = -1
        Private _impFatture As Double = 0
        Private _impNote As Double = 0

        Public Property nContribuenti() As Integer
            Get
                Return _nContribuenti
            End Get
            Set(ByVal Value As Integer)
                _nContribuenti = Value
            End Set
        End Property
        Public Property nFatture() As Integer
            Get
                Return _nFatture
            End Get
            Set(ByVal Value As Integer)
                _nFatture = Value
            End Set
        End Property
        Public Property nNote() As Integer
            Get
                Return _nNote
            End Get
            Set(ByVal Value As Integer)
                _nNote = Value
            End Set
        End Property
        Public Property impFatture() As Double
            Get
                Return _impFatture
            End Get
            Set(ByVal Value As Double)
                _impFatture = Value
            End Set
        End Property
        Public Property impNote() As Double
            Get
                Return _impNote
            End Get
            Set(ByVal Value As Double)
                _impNote = Value
            End Set
        End Property
    End Class
End Namespace