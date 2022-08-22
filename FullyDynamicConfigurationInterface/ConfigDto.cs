namespace FullyDynamicConfigurationInterface;

public interface ConfigDto {
	// This requires .net 7.
	public static abstract Type ParamsDtoType { get; }
}

public interface ConfigDto<TParamsDto> : ConfigDto where TParamsDto : IParamsDto {
	// Also I'd prefer if they will add support for static abstract members on abstract classes. I don't like doing this with an interface.
	// I hope this is going to work at all.
	public sealed static default override Type ParamsDtoType => typeof(TParamsDto);
}
