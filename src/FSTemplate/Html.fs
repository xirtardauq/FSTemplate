namespace FSTemplate

open System
open Element

[<AutoOpen>]
module Html =     
    
    /// <summary>
    /// Defines a hyperlink
    /// </summary>
    let a = pairedTag "a"
    
    /// <summary>
    /// Defines an abbreviation or an acronym
    /// </summary>
    let abbr = pairedTag "abbr"
    
    /// <summary>
    /// Defines contact information for the author/owner of a document
    /// </summary>
    let address = pairedTag "address"
    
    /// <summary>
    /// Defines an area inside an image-map
    /// </summary>
    let area = pairedTag "area"
    
    /// <summary>
    /// Defines an article
    /// </summary>
    let article = pairedTag "article"
    
    /// <summary>
    /// Defines content aside from the page content
    /// </summary>
    let aside = pairedTag "aside"
    
    /// <summary>
    /// Defines sound content
    /// </summary>
    let audio = pairedTag "audio"
    
    /// <summary>
    /// Defines bold text
    /// </summary>
    let b = pairedTag "b"
    
    /// <summary>
    /// Specifies the base URL/target for all relative URLs in a document
    /// </summary>
    let base' = unpairedTag "base"
    
    /// <summary>
    /// Isolates a part of text that might be formatted in a different direction 
    ///    from other text outside it
    /// </summary>
    let bdi = pairedTag "bdi"
    
    /// <summary>
    /// Overrides the current text direction
    /// </summary>
    let bdo = pairedTag "bdo"
    
    /// <summary>
    /// Defines a section that is quoted from another source
    /// </summary>
    let blockquote = pairedTag "blockquote"
    
    /// <summary>
    /// Defines a single line break
    /// </summary>
    let br = unpairedTag "br"
    
    /// <summary>
    /// Defines a clickable button
    /// </summary>
    let button = pairedTag "button"
    
    /// <summary>
    /// Used to draw graphics, on the fly, via scripting (usually JavaScript)
    /// </summary>
    let canvas = pairedTag "canvas"
    
    /// <summary>
    /// Defines a table caption
    /// </summary>
    let caption = pairedTag "caption"
    
    /// <summary>
    /// Defines the title of a work
    /// </summary>
    let cite = pairedTag "cite"
    
    /// <summary>
    /// Defines a piece of computer code
    /// </summary>
    let code = pairedTag "code"
    
    /// <summary>
    /// Specifies column properties for each column within a <colgroup> element 
    /// </summary>
    let col = pairedTag "col"
    
    /// <summary>
    /// Specifies a group of one or more columns in a table for formatting
    /// </summary>
    let colgroup = pairedTag "colgroup"
    
    /// <summary>
    /// Specifies a list of pre-defined options for input controls
    /// </summary>
    let datalist = pairedTag "datalist"
    
    /// <summary>
    /// Defines a description/value of a term in a description list
    /// </summary>
    let dd = pairedTag "dd"
    
    /// <summary>
    /// Defines text that has been deleted from a document
    /// </summary>
    let del = pairedTag "del"
    
    /// <summary>
    /// Defines additional details that the user can view or hide
    /// </summary>
    let details = pairedTag "details"
    
    /// <summary>
    /// Represents the defining instance of a term
    /// </summary>
    let dfn = pairedTag "dfn"
    
    /// <summary>
    /// Defines a dialog box or window
    /// </summary>
    let dialog = pairedTag "dialog"
    
    /// <summary>
    /// Defines a section in a document
    /// </summary>
    let div = pairedTag "div"
    
    /// <summary>
    /// Defines a description list
    /// </summary>
    let dl = pairedTag "dl"
    
    /// <summary>
    /// Defines a term/name in a description list
    /// </summary>
    let dt = pairedTag "dt"
    
    /// <summary>
    /// Defines emphasized text 
    /// </summary>
    let em = pairedTag "em"
    
    /// <summary>
    /// Defines a container for an external (non-HTML) application
    /// </summary>
    let embed = pairedTag "embed"
    
    /// <summary>
    /// Groups related elements in a form
    /// </summary>
    let fieldset = pairedTag "fieldset"
    
    /// <summary>
    /// Defines a caption for a <figure> element
    /// </summary>
    let figcaption = pairedTag "figcaption"
    
    /// <summary>
    /// Specifies self-contained content
    /// </summary>
    let figure = pairedTag "figure"
    
    /// <summary>
    /// Defines a footer for a document or section
    /// </summary>
    let footer = pairedTag "footer"
    
    /// <summary>
    /// Defines an HTML form for user input
    /// </summary>
    let form = pairedTag "form"
    
    /// <summary>
    /// Defines a header for a document or section
    /// </summary>
    let header = pairedTag "header"
    
    /// <summary>
    ///  Defines a thematic change in the content
    /// </summary>
    let hr = unpairedTag "hr"
    
    /// <summary>
    /// Defines a part of text in an alternate voice or mood
    /// </summary>
    let i = pairedTag "i"
    
    /// <summary>
    /// Defines an inline frame
    /// </summary>
    let iframe = pairedTag "iframe"
    
    /// <summary>
    /// Defines an image
    /// </summary>
    let img = pairedTag "img"
    
    /// <summary>
    /// Defines an input control
    /// </summary>
    let input = unpairedTag "input"
    
    /// <summary>
    /// Defines a text that has been inserted into a document
    /// </summary>
    let ins = pairedTag "ins"
    
    /// <summary>
    /// Defines keyboard input
    /// </summary>
    let kbd = pairedTag "kbd"
    
    /// <summary>
    /// Defines a key-pair generator field (for forms)
    /// </summary>
    let keygen = pairedTag "keygen"
    
    /// <summary>
    /// Defines a label for an <input> element
    /// </summary>
    let label = pairedTag "label"
    
    /// <summary>
    /// Defines a caption for a <fieldset> element
    /// </summary>
    let legend = pairedTag "legend"
    
    /// <summary>
    /// Defines a list item
    /// </summary>
    let li = pairedTag "li"
    
    /// <summary>
    /// Defines the relationship between a document and an external resource (most 
    /// used to link to style sheets)
    /// </summary>
    let link = unpairedTag "link"
    
    /// <summary>
    /// Specifies the main content of a document
    /// </summary>
    let main = pairedTag "main"
    
    /// <summary>
    /// Defines a client-side image-map
    /// </summary>
    let map = pairedTag "map"
    
    /// <summary>
    /// Defines marked/highlighted text
    /// </summary>
    let mark = pairedTag "mark"
    
    /// <summary>
    /// Defines a list/menu of commands
    /// </summary>
    let menu = pairedTag "menu"
    
    /// <summary>
    /// Defines a command/menu item that the user can invoke from a popup menu
    /// </summary>
    let menuitem = pairedTag "menuitem"
    
    /// <summary>
    /// Defines metadata about an HTML document
    /// </summary>
    let meta = unpairedTag "meta"
    
    /// <summary>
    /// Defines a scalar measurement within a known range (a gauge)
    /// </summary>
    let meter = pairedTag "meter"
    
    /// <summary>
    /// Defines navigation links
    /// </summary>
    let nav = pairedTag "nav"
    
    /// <summary>
    /// Defines an alternate content for users that do not support 
    /// client-side scripts
    /// </summary>
    let noscript = pairedTag "noscript"
    
    /// <summary>
    /// Defines an embedded object
    /// </summary>
    let object' = pairedTag "object"
    
    /// <summary>
    /// Defines an ordered list
    /// </summary>
    let ol = pairedTag "ol"
    
    /// <summary>
    /// Defines a group of related options in a drop-down list
    /// </summary>
    let optgroup = pairedTag "optgroup"
    
    /// <summary>
    /// Defines an option in a drop-down list
    /// </summary>
    let option = pairedTag "option"
    
    /// <summary>
    /// Defines the result of a calculation
    /// </summary>
    let output = pairedTag "output"
    
    /// <summary>
    /// Defines a paragraph
    /// </summary>
    let p = pairedTag "p"
    
    /// <summary>
    /// Defines a parameter for an object
    /// </summary>
    let param = pairedTag "param"
    
    /// <summary>
    /// Defines a container for multiple image resources
    /// </summary>
    let picture = pairedTag "picture"
    
    /// <summary>
    /// Defines preformatted text
    /// </summary>
    let pre = pairedTag "pre"
    
    /// <summary>
    /// Represents the progress of a task
    /// </summary>
    let progress = pairedTag "progress"
    
    /// <summary>
    /// Defines a short quotation
    /// </summary>
    let q = pairedTag "q"
    
    /// <summary>
    /// Defines what to show in browsers that do not support ruby annotations
    /// </summary>
    let rp = pairedTag "rp"
    
    /// <summary>
    /// Defines an explanation/pronunciation of characters (for East Asian typography)
    /// </summary>
    let rt = pairedTag "rt"
    
    /// <summary>
    /// Defines a ruby annotation (for East Asian typography)
    /// </summary>
    let ruby = pairedTag "ruby"
    
    /// <summary>
    /// Defines text that is no longer correct
    /// </summary>
    let s = pairedTag "s"
    
    /// <summary>
    /// Defines sample output from a computer program
    /// </summary>
    let samp = pairedTag "samp"
    
    /// <summary>
    /// Defines a section in a document
    /// </summary>
    let section = pairedTag "section"
    
    /// <summary>
    /// Defines a drop-down list
    /// </summary>
    let select = pairedTag "select"
    
    /// <summary>
    /// Defines smaller text
    /// </summary>
    let small = pairedTag "small"
    
    /// <summary>
    /// Defines multiple media resources for media elements (<video> and <audio>)
    /// </summary>
    let source = pairedTag "source"
    
    /// <summary>
    /// Defines a section in a document
    /// </summary>
    let span = pairedTag "span"
    
    /// <summary>
    /// Defines important text
    /// </summary>
    let strong = pairedTag "strong"
    
    /// <summary>
    /// Defines style information for a document
    /// </summary>
    let style = pairedTag "style"
    
    /// <summary>
    /// Defines subscripted text
    /// </summary>
    let sub = pairedTag "sub"
    
    /// <summary>
    /// Defines a visible heading for a <details> element
    /// </summary>
    let summary = pairedTag "summary"
    
    /// <summary>
    /// Defines superscripted text
    /// </summary>
    let sup = pairedTag "sup"
    
    /// <summary>
    /// Defines a table
    /// </summary>
    let table = pairedTag "table"
    
    /// <summary>
    /// Groups the body content in a table
    /// </summary>
    let tbody = pairedTag "tbody"
    
    /// <summary>
    /// Defines a cell in a table
    /// </summary>
    let td = pairedTag "td"
    
    /// <summary>
    /// Defines a multiline input control (text area)
    /// </summary>
    let textarea = pairedTag "textarea"
    
    /// <summary>
    /// Groups the footer content in a table
    /// </summary>
    let tfoot = pairedTag "tfoot"
    
    /// <summary>
    /// Defines a header cell in a table
    /// </summary>
    let th = pairedTag "th"
    
    /// <summary>
    /// Groups the header content in a table
    /// </summary>
    let thead = pairedTag "thead"
    
    /// <summary>
    /// Defines a date/time
    /// </summary>
    let time = pairedTag "time"
    
    /// <summary>
    /// Defines a title for the document
    /// </summary>
    let title = pairedTag "title"
    
    /// <summary>
    /// Defines a row in a table
    /// </summary>
    let tr = pairedTag "tr"
    
    /// <summary>
    /// Defines text tracks for media elements (<video> and <audio>)
    /// </summary>
    let track = pairedTag "track"
    
    /// <summary>
    /// Defines text that should be stylistically different from normal text
    /// </summary>
    let u = pairedTag "u"
    
    /// <summary>
    /// Defines an unordered list
    /// </summary>
    let ul = pairedTag "ul"
    
    /// <summary>
    /// Defines a variable
    /// </summary>
    let var = pairedTag "var"
    
    /// <summary>
    /// Defines a video or movie
    /// </summary>
    let video = pairedTag "video"
    
    /// <summary>
    /// Defines a possible line-break
    /// </summary>
    let wbr = pairedTag "wbr"
    
    /// <summary>
    /// Simple text node
    /// </summary>
    let text = Element.Text
    
    let private head = pairedTag "head"
    let private body = pairedTag "body"    
    let html head_ body_ = 
        pairedTag "html" [] [head [] head_; body [] body_]

    /// <summary>
    /// Specifies one or more classnames for an element
    /// </summary>
    let class' = attr "class"

    /// <summary>
    /// Specifies a unique id for an element
    /// </summary>
    let id' = attr "id"

    /// <summary>
    /// Specifies the URL of the page the link goes to
    /// </summary>
    let href = attr "href"

    /// <summary>
    /// Specifies the URL of the media file
    /// </summary>
    let src = attr "src"

    let on event = 
        attr ("on" + event)

    let stylesheet path = 
        pairedTag "link" [Attr("rel", "stylesheet"); (href path)] []

    let script path = 
        pairedTag "script" [(src path)] []

    // marker attribute
    type Render() =
        inherit Attribute()

