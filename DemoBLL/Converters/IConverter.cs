namespace CustomerSystemBLL.Converters
{
    interface IConverter <IEntity, IBusinessObject>
    {
        IEntity Convert(IBusinessObject businessObject);
        IBusinessObject Convert(IEntity entity);
    }
}
