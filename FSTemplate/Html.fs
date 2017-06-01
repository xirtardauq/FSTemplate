namespace FSTemplate

open System
open Element

module Html =     
    
    /// <summary>
    /// Defines a hyperlink
    /// </summary>
    let a = element "a"
    
    /// <summary>
    /// Defines an abbreviation or an acronym
    /// </summary>
    let abbr = element "abbr"
    
    /// <summary>
    /// Defines contact information for the author/owner of a document
    /// </summary>
    let address = element "address"
    
    /// <summary>
    /// Defines an area inside an image-map
    /// </summary>
    let area = element "area"
    
    /// <summary>
    /// Defines an article
    /// </summary>
    let article = element "article"
    
    /// <summary>
    /// Defines content aside from the page content
    /// </summary>
    let aside = element "aside"
    
    /// <summary>
    /// Defines sound content
    /// </summary>
    let audio = element "audio"
    
    /// <summary>
    /// Defines bold text
    /// </summary>
    let b = element "b"
    
    /// <summary>
    /// Specifies the base URL/target for all relative URLs in a document
    /// </summary>
    let base' = element "base"
    
    /// <summary>
    /// Isolates a part of text that might be formatted in a different direction 
    ///    from other text outside it
    /// </summary>
    let bdi = element "bdi"
    
    /// <summary>
    /// Overrides the current text direction
    /// </summary>
    let bdo = element "bdo"
    
    /// <summary>
    /// Defines a section that is quoted from another source
    /// </summary>
    let blockquote = element "blockquote"
    
    /// <summary>
    /// Defines a single line break
    /// </summary>
    let br = element "br"
    
    /// <summary>
    /// Defines a clickable button
    /// </summary>
    let button = element "button"
    
    /// <summary>
    /// Used to draw graphics, on the fly, via scripting (usually JavaScript)
    /// </summary>
    let canvas = element "canvas"
    
    /// <summary>
    /// Defines a table caption
    /// </summary>
    let caption = element "caption"
    
    /// <summary>
    /// Defines the title of a work
    /// </summary>
    let cite = element "cite"
    
    /// <summary>
    /// Defines a piece of computer code
    /// </summary>
    let code = element "code"
    
    /// <summary>
    /// Specifies column properties for each column within a <colgroup> element 
    /// </summary>
    let col = element "col"
    
    /// <summary>
    /// Specifies a group of one or more columns in a table for formatting
    /// </summary>
    let colgroup = element "colgroup"
    
    /// <summary>
    /// Specifies a list of pre-defined options for input controls
    /// </summary>
    let datalist = element "datalist"
    
    /// <summary>
    /// Defines a description/value of a term in a description list
    /// </summary>
    let dd = element "dd"
    
    /// <summary>
    /// Defines text that has been deleted from a document
    /// </summary>
    let del = element "del"
    
    /// <summary>
    /// Defines additional details that the user can view or hide
    /// </summary>
    let details = element "details"
    
    /// <summary>
    /// Represents the defining instance of a term
    /// </summary>
    let dfn = element "dfn"
    
    /// <summary>
    /// Defines a dialog box or window
    /// </summary>
    let dialog = element "dialog"
    
    /// <summary>
    /// Defines a section in a document
    /// </summary>
    let div = element "div"
    
    /// <summary>
    /// Defines a description list
    /// </summary>
    let dl = element "dl"
    
    /// <summary>
    /// Defines a term/name in a description list
    /// </summary>
    let dt = element "dt"
    
    /// <summary>
    /// Defines emphasized text 
    /// </summary>
    let em = element "em"
    
    /// <summary>
    /// Defines a container for an external (non-HTML) application
    /// </summary>
    let embed = element "embed"
    
    /// <summary>
    /// Groups related elements in a form
    /// </summary>
    let fieldset = element "fieldset"
    
    /// <summary>
    /// Defines a caption for a <figure> element
    /// </summary>
    let figcaption = element "figcaption"
    
    /// <summary>
    /// Specifies self-contained content
    /// </summary>
    let figure = element "figure"
    
    /// <summary>
    /// Defines a footer for a document or section
    /// </summary>
    let footer = element "footer"
    
    /// <summary>
    /// Defines an HTML form for user input
    /// </summary>
    let form = element "form"
    
    /// <summary>
    /// Defines a header for a document or section
    /// </summary>
    let header = element "header"
    
    /// <summary>
    ///  Defines a thematic change in the content
    /// </summary>
    let hr = element "hr"
    
    /// <summary>
    /// Defines a part of text in an alternate voice or mood
    /// </summary>
    let i = element "i"
    
    /// <summary>
    /// Defines an inline frame
    /// </summary>
    let iframe = element "iframe"
    
    /// <summary>
    /// Defines an image
    /// </summary>
    let img = element "img"
    
    /// <summary>
    /// Defines an input control
    /// </summary>
    let input = element "input"
    
    /// <summary>
    /// Defines a text that has been inserted into a document
    /// </summary>
    let ins = element "ins"
    
    /// <summary>
    /// Defines keyboard input
    /// </summary>
    let kbd = element "kbd"
    
    /// <summary>
    /// Defines a key-pair generator field (for forms)
    /// </summary>
    let keygen = element "keygen"
    
    /// <summary>
    /// Defines a label for an <input> element
    /// </summary>
    let label = element "label"
    
    /// <summary>
    /// Defines a caption for a <fieldset> element
    /// </summary>
    let legend = element "legend"
    
    /// <summary>
    /// Defines a list item
    /// </summary>
    let li = element "li"
    
    /// <summary>
    /// Defines the relationship between a document and an external resource (most 
    /// used to link to style sheets)
    /// </summary>
    let link = element "link"
    
    /// <summary>
    /// Specifies the main content of a document
    /// </summary>
    let main = element "main"
    
    /// <summary>
    /// Defines a client-side image-map
    /// </summary>
    let map = element "map"
    
    /// <summary>
    /// Defines marked/highlighted text
    /// </summary>
    let mark = element "mark"
    
    /// <summary>
    /// Defines a list/menu of commands
    /// </summary>
    let menu = element "menu"
    
    /// <summary>
    /// Defines a command/menu item that the user can invoke from a popup menu
    /// </summary>
    let menuitem = element "menuitem"
    
    /// <summary>
    /// Defines metadata about an HTML document
    /// </summary>
    let meta = element "meta"
    
    /// <summary>
    /// Defines a scalar measurement within a known range (a gauge)
    /// </summary>
    let meter = element "meter"
    
    /// <summary>
    /// Defines navigation links
    /// </summary>
    let nav = element "nav"
    
    /// <summary>
    /// Defines an alternate content for users that do not support 
    /// client-side scripts
    /// </summary>
    let noscript = element "noscript"
    
    /// <summary>
    /// Defines an embedded object
    /// </summary>
    let object' = element "object"
    
    /// <summary>
    /// Defines an ordered list
    /// </summary>
    let ol = element "ol"
    
    /// <summary>
    /// Defines a group of related options in a drop-down list
    /// </summary>
    let optgroup = element "optgroup"
    
    /// <summary>
    /// Defines an option in a drop-down list
    /// </summary>
    let option = element "option"
    
    /// <summary>
    /// Defines the result of a calculation
    /// </summary>
    let output = element "output"
    
    /// <summary>
    /// Defines a paragraph
    /// </summary>
    let p = element "p"
    
    /// <summary>
    /// Defines a parameter for an object
    /// </summary>
    let param = element "param"
    
    /// <summary>
    /// Defines a container for multiple image resources
    /// </summary>
    let picture = element "picture"
    
    /// <summary>
    /// Defines preformatted text
    /// </summary>
    let pre = element "pre"
    
    /// <summary>
    /// Represents the progress of a task
    /// </summary>
    let progress = element "progress"
    
    /// <summary>
    /// Defines a short quotation
    /// </summary>
    let q = element "q"
    
    /// <summary>
    /// Defines what to show in browsers that do not support ruby annotations
    /// </summary>
    let rp = element "rp"
    
    /// <summary>
    /// Defines an explanation/pronunciation of characters (for East Asian typography)
    /// </summary>
    let rt = element "rt"
    
    /// <summary>
    /// Defines a ruby annotation (for East Asian typography)
    /// </summary>
    let ruby = element "ruby"
    
    /// <summary>
    /// Defines text that is no longer correct
    /// </summary>
    let s = element "s"
    
    /// <summary>
    /// Defines sample output from a computer program
    /// </summary>
    let samp = element "samp"
    
    /// <summary>
    /// Defines a section in a document
    /// </summary>
    let section = element "section"
    
    /// <summary>
    /// Defines a drop-down list
    /// </summary>
    let select = element "select"
    
    /// <summary>
    /// Defines smaller text
    /// </summary>
    let small = element "small"
    
    /// <summary>
    /// Defines multiple media resources for media elements (<video> and <audio>)
    /// </summary>
    let source = element "source"
    
    /// <summary>
    /// Defines a section in a document
    /// </summary>
    let span = element "span"
    
    /// <summary>
    /// Defines important text
    /// </summary>
    let strong = element "strong"
    
    /// <summary>
    /// Defines style information for a document
    /// </summary>
    let style = element "style"
    
    /// <summary>
    /// Defines subscripted text
    /// </summary>
    let sub = element "sub"
    
    /// <summary>
    /// Defines a visible heading for a <details> element
    /// </summary>
    let summary = element "summary"
    
    /// <summary>
    /// Defines superscripted text
    /// </summary>
    let sup = element "sup"
    
    /// <summary>
    /// Defines a table
    /// </summary>
    let table = element "table"
    
    /// <summary>
    /// Groups the body content in a table
    /// </summary>
    let tbody = element "tbody"
    
    /// <summary>
    /// Defines a cell in a table
    /// </summary>
    let td = element "td"
    
    /// <summary>
    /// Defines a multiline input control (text area)
    /// </summary>
    let textarea = element "textarea"
    
    /// <summary>
    /// Groups the footer content in a table
    /// </summary>
    let tfoot = element "tfoot"
    
    /// <summary>
    /// Defines a header cell in a table
    /// </summary>
    let th = element "th"
    
    /// <summary>
    /// Groups the header content in a table
    /// </summary>
    let thead = element "thead"
    
    /// <summary>
    /// Defines a date/time
    /// </summary>
    let time = element "time"
    
    /// <summary>
    /// Defines a title for the document
    /// </summary>
    let title = element "title"
    
    /// <summary>
    /// Defines a row in a table
    /// </summary>
    let tr = element "tr"
    
    /// <summary>
    /// Defines text tracks for media elements (<video> and <audio>)
    /// </summary>
    let track = element "track"
    
    /// <summary>
    /// Defines text that should be stylistically different from normal text
    /// </summary>
    let u = element "u"
    
    /// <summary>
    /// Defines an unordered list
    /// </summary>
    let ul = element "ul"
    
    /// <summary>
    /// Defines a variable
    /// </summary>
    let var = element "var"
    
    /// <summary>
    /// Defines a video or movie
    /// </summary>
    let video = element "video"
    
    /// <summary>
    /// Defines a possible line-break
    /// </summary>
    let wbr = element "wbr"
    
    /// <summary>
    /// Simple text node
    /// </summary>
    let text = Element.Text
    
    let private head = element "head"
    let private body = element "body"    
    let html head_ body_ = 
        element "html" [] [head [] head_; body [] body_]

    let stylesheet path = 
        element "link" [Attr("rel", "stylesheet"); Attr("href", path)] []

    let script path = 
        element "script" [Attr("src", path)] []

    // marker attribute
    type Render() =
        inherit Attribute()

