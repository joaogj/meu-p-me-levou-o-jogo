namespace MeuPMeLevou.Phone
{
    // Pure open/closed state of the phone screen. Tab toggles it; Esc closes it.
    public sealed class PhoneMenuState
    {
        public bool IsOpen { get; private set; }

        public void Toggle()
        {
            IsOpen = !IsOpen;
        }

        // Closes the screen. Returns whether it was open, so the caller knows Esc was used up
        // closing the phone instead of doing something else (such as pausing).
        public bool Close()
        {
            bool wasOpen = IsOpen;
            IsOpen = false;
            return wasOpen;
        }
    }
}
