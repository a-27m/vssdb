//
// imath.h
//

// {8E771142-3F6B-4d86-A0E9-A44E1A2CA3BB}
DEFINE_GUID( CLSID_Math, 
			 0x8e771142, 0x3f6b, 0x4d86, 0xa0, 0xe9, 0xa4, 0x4e, 0x1a, 0x2c, 0xa3, 0xbb);

// {8E771142-3F6B-4d86-A0E9-A44E1A2CA3BB}
DEFINE_GUID( CLSID_Math, 
			 0x8e771142, 0x3f6b, 0x4d86, 0xa0, 0xe9, 0xa4, 0x4e, 0x1a, 0x2c, 0xa3, 0xbb);

class IMath : public IUnknown
{
public:
   STDMETHOD( Add( long, long, long* ))      PURE;
   STDMETHOD( Subtract( long, long, long* )) PURE;
   STDMETHOD( Multiply( long, long, long* )) PURE;
   STDMETHOD( Divide( long, long, long* ))   PURE;
};
