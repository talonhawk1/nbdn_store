namespace nothinbutdotnetprep.utility.filtering
{
    public class NotCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        CriteriaFactory<ItemToFilter, PropertyType> original;

        public NotCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> original)
        {
            this.original = original;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return new NotCriteria<ItemToFilter>(original.equal_to_any(values));
        }
    }
}