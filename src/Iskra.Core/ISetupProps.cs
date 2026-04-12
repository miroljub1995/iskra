namespace Iskra.Core;

public interface ISetupProps<in TInitProps, out TProps>
{
    public static abstract TProps Init(TInitProps initProps);
}