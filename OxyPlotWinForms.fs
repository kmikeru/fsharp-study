open System.Windows.Forms
open OxyPlot
open OxyPlot.Series
open OxyPlot.WindowsForms

let XYtoPoint a =
    let x=fst a
    let y=snd a
    new DataPoint(x,y)

let listToPoints a =
    List.map XYtoPoint a

let XYPlot (t: (float*float) list) =

    let p = listToPoints t
    let pm = new PlotModel( PlotType = PlotType.XY)
    let s=new LineSeries()

    for point in p do
        s.Points.Add(point) 

    pm.Series.Add(s)
    let plot =new OxyPlot.WindowsForms.PlotView()
    plot.Model <- pm
    plot.Dock <- System.Windows.Forms.DockStyle.Fill
    let form = new Form()
    form.Controls.Add(plot)
    plot.Show()
    form.Show()
    Application.Run(form)

[<EntryPoint>]
let main argv = 
    let l=[(0.0,0.0);(1.0,1.0);(2.0,2.0)]

    XYPlot l

    0 // return an integer exit code
