namespace FullyDynamicConfigurationInterface;

public abstract class ConfigDtoProducer<TConfigDto, TParamsDto> where TConfigDto : ConfigDto<TParamsDto> where TParamsDto : IParamsDto {
	public abstract Task<TConfigDto> ProduceAsync(TParamsDto parameters);
}
