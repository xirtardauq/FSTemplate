namespace FSTemplate

module Config =

    [<AllowNullLiteral>]
    type FSTemplateConfig(cacheProvider, viewResolver: IViewResolver) =         
        member val CacheProvider: ICacheProvider = cacheProvider with get,set
        
        member val ViewResolver = viewResolver with get


    module ConfigStore =
        let mutable private x: Lazy<FSTemplateConfig> = null

        let GetInstance() = 
            if x = null then 
                null 
            else 
                x.Value

        let SetInstance(value) = 
            x <- lazy(value)