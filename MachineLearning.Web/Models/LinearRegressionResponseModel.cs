namespace MachineLearning.Web.Models;

public class LinearRegressionResponseModel
{
    public List<int> x_train { get; set; }
    public List<int> x_test { get; set; }
    public List<int> y_train { get; set; }
    public List<int> y_test { get; set; }
    public List<int> y_prediction { get; set; }
}