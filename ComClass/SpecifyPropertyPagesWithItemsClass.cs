using System;
using System.Drawing;
using System.Runtime.InteropServices;
using static Interop;
using static Interop.Ole32;

namespace ComClass
{
    [ComVisible(true)]
    [Guid("fb73707c-8950-4490-a536-f9bf8be1e686")]
    public class SpecifyPropertyPagesWithItemsClass : IOleObject, ISpecifyPropertyPages
    {
        unsafe HRESULT ISpecifyPropertyPages.GetPages(CAUUID* pPages)
        {
            pPages->cElems = 1;
            pPages->pElems = (Guid*)Marshal.AllocCoTaskMem((int)(sizeof(Guid) * 1));
            return HRESULT.S_OK;
        }

        HRESULT IOleObject.SetClientSite(IOleClientSite pClientSite)
        {
            return HRESULT.S_OK;
        }

        HRESULT IOleObject.GetClientSite(out IOleClientSite ppClientSite)
        {
            ppClientSite = null;
            return HRESULT.S_OK;
        }

        HRESULT IOleObject.SetHostNames(string szContainerApp, string szContainerObj)
        {
            return HRESULT.S_OK;
        }

        HRESULT IOleObject.Close(OLECLOSE dwSaveOption)
        {
            return HRESULT.S_OK;
        }

        HRESULT IOleObject.SetMoniker(OLEWHICHMK dwWhichMoniker, object pmk)
        {
            return HRESULT.S_OK;
        }

        unsafe HRESULT IOleObject.GetMoniker(OLEGETMONIKER dwAssign, OLEWHICHMK dwWhichMoniker, IntPtr* ppmk)
        {
            return HRESULT.S_OK;
        }

        HRESULT IOleObject.InitFromData(System.Runtime.InteropServices.ComTypes.IDataObject pDataObject, BOOL fCreation, uint dwReserved)
        {
            return HRESULT.S_OK;
        }

        HRESULT IOleObject.GetClipboardData(uint dwReserved, out System.Runtime.InteropServices.ComTypes.IDataObject ppDataObject)
        {
            ppDataObject = null;
            return HRESULT.S_OK;
        }

        unsafe HRESULT IOleObject.DoVerb(OLEIVERB iVerb, User32.MSG* lpmsg, IOleClientSite pActiveSite, int lindex, IntPtr hwndParent, RECT* lprcPosRect)
        {
            return HRESULT.S_OK;
        }

        HRESULT IOleObject.EnumVerbs(out IEnumOLEVERB ppEnumOleVerb)
        {
            ppEnumOleVerb = null;
            return HRESULT.S_OK;
        }

        HRESULT IOleObject.OleUpdate()
        {
            return HRESULT.S_OK;
        }

        HRESULT IOleObject.IsUpToDate()
        {
            return HRESULT.S_OK;
        }

        unsafe HRESULT IOleObject.GetUserClassID(Guid* pClsid)
        {
            return HRESULT.S_OK;
        }

        HRESULT IOleObject.GetUserType(USERCLASSTYPE dwFormOfType, out string userType)
        {
            userType = null;
            return HRESULT.S_OK;
        }

        unsafe HRESULT IOleObject.SetExtent(DVASPECT dwDrawAspect, Size* pSizel)
        {
            return HRESULT.S_OK;
        }

        unsafe HRESULT IOleObject.GetExtent(DVASPECT dwDrawAspect, Size* pSizel)
        {
            return HRESULT.S_OK;
        }

        unsafe HRESULT IOleObject.Advise(System.Runtime.InteropServices.ComTypes.IAdviseSink pAdvSink, uint* pdwConnection)
        {
            return HRESULT.S_OK;
        }

        HRESULT IOleObject.Unadvise(uint dwConnection)
        {
            return HRESULT.S_OK;
        }

        HRESULT IOleObject.EnumAdvise(out System.Runtime.InteropServices.ComTypes.IEnumSTATDATA e)
        {
            e = null;
            return HRESULT.S_OK;
        }

        unsafe HRESULT IOleObject.GetMiscStatus(DVASPECT dwAspect, OLEMISC* pdwStatus)
        {
            return HRESULT.S_OK;
        }

        unsafe HRESULT IOleObject.SetColorScheme(Gdi32.LOGPALETTE* pLogpal)
        {
            return HRESULT.S_OK;
        }
    }
}
