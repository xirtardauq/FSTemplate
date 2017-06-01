namespace FSTemplate

module Config =

    type FSTemplateConfig(cacheProvider, viewResolver: IViewResolver) =         
        member val CacheProvider: ICacheProvider = cacheProvider with get,set
        
        member val ViewResolver = viewResolver with get


    module ConfigStore =
        let mutable private x: Lazy<FSTemplateConfig> = null

        let GetInstance() = x.Value

        let SetInstance(value) = 
            x <- lazy(value)