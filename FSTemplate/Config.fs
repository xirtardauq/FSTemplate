namespace FSTemplate

module Config =

    open Base

    type FSTemplateConfig(cacheProvider, viewPathTemplate: string) =         
        member val CacheProvider: ICacheProvider = cacheProvider with get,set
        
        member val ViewPathTemplate = viewPathTemplate with get

    module ConfigStore =
        let mutable private x: Lazy<FSTemplateConfig> = null

        let GetInstance() = x.Value

        let SetInstance(value) = 
            x <- lazy(value)