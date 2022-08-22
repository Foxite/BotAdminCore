namespace FullyDynamicConfigurationInterface;

public abstract class ConfigDtoConsumer<TConfigDto, TParamsDto> where TConfigDto : ConfigDto<TParamsDto> where TParamsDto : IParamsDto {
	public abstract Task<ConsumptionResult> ConsumeAsync(TParamsDto parameters, TConfigDto configDto);
}
