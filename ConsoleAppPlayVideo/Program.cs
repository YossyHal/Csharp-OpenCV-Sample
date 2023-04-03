using OpenCvSharp;

string movie = Path.Combine("movie", "bach.mp4");
if (File.Exists(movie))
{
    Console.WriteLine("'" + movie + "' exists.");
}
else
{
    Console.WriteLine("'" + movie + "' does not exist.");
    return;
}

using var capture = new VideoCapture(movie);
if (!capture.IsOpened())
{
    Console.WriteLine("Could not load movie...");
    return;
}

var image = new Mat();
using var window = new Window("capture");
int sleepTime = (int)Math.Round(1000 / capture.Fps);

while (true)
{
    capture.Read(image); // same as cvQueryFrame
    if (image.Empty())
        break;
    window.ShowImage(image);
    int key = Cv2.WaitKey(sleepTime);
    if (key == 27) break; // ESC キーで閉じる
}
