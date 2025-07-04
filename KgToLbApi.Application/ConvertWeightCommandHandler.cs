using KgToLbApi.Domain; 

namespace KgToLbApi.Application   
{
    public class ConvertWeightCommandHandler
    {
        private readonly WeightConversionService _service;

        public ConvertWeightCommandHandler()
        {
            _service = new WeightConversionService();
        }

        public object Handle(ConvertWeightCommand command)
        {
            var pounds = _service.ConvertKgToPounds(command.Kilograms);

            return new
            {
                kilograms = command.Kilograms,
                pounds = pounds
            };
        }
    }
}
