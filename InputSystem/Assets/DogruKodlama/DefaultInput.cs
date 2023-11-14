
namespace InputSystem.DogruKodlama
{
    public class DefaultInput
    {

        private DefaultAction _input; // sýnýfýnýn yapýcý (constructor) metodunu tanýmlar.

        public bool IsForceUp { get; private set; }
        public DefaultInput()
        {
            _input = new DefaultAction();

            _input.Rocket.ForceUp.performed += x => IsForceUp = x.ReadValueAsButton();

            _input.Enable();
        }
        


    }
}

