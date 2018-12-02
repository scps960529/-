using SystemFramework.Events;

namespace MainProject.Events
{
    public class PageIDEventArgs : ValueEventArgs<EPageID>
    {
        public PageIDEventArgs(EPageID id)
            :base(id)
        { }
    }
}
