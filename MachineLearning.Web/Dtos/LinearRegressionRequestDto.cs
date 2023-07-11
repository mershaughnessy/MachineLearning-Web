namespace MachineLearning.Web.Dtos;

public class LinearRegressionRequestDto
{
    public List<int> IndependentVariable { get; set; }
    public List<int> DependentVariable { get; set; }
}