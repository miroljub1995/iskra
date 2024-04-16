namespace IskraSample;

public partial class HelloWorld
{
    private class HelloWorldReactive(IskraSample.HelloWorld source) : IskraSample.HelloWorld
    {
        private string _testProp = source.TestProp;

        public override string TestProp
        {
            get
            {
                // track
                return _testProp;
            }
            set
            {
                _testProp = value;
                // notify
            }
        }

        private string _testAnotherProp = source.TestAnotherProp;

        public override string TestAnotherProp
        {
            get
            {
                // track
                return _testAnotherProp;
            }
            set
            {
                _testAnotherProp = value;
                // notify
            }
        }
    }

    public Ref<IskraSample.HelloWorld> ToRef()
    {
        return new Ref<IskraSample.HelloWorld>(this is HelloWorldReactive ? this : new HelloWorldReactive(this));
    }
}