namespace CommonLibrary.Server;

[ApiController]
public class BaseSettingController<TEntity, TViewModel> : ControllerBase
    where TEntity : BaseEntity
    where TViewModel : BaseViewModel
{
    private readonly IBaseSettingUnitOfWork<TEntity, TViewModel> _unitOfWork;
    private readonly IValidator<TViewModel> _validator;

    public BaseSettingController(IBaseSettingUnitOfWork<TEntity, TViewModel> unitOfWork, IValidator<TViewModel> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    [HttpGet]
    public virtual async Task<IActionResult> Get()
    {
        TViewModel viewModel = await _unitOfWork.ReadAsync();
        return Ok(viewModel);
    }

    [HttpPut]
    public virtual async Task<IActionResult> Put(TViewModel viewModel)
    {

        if (viewModel == null)
            return BadRequest("ViewModel can not be null");

        var result = _validator.Validate(viewModel);
        if (!result.IsValid)
        {
            string text = string.Join("-", result.Errors.Select(e => e.ErrorMessage));
            throw new Exception("NonValid ViewModel Reason:" + text);
        }

        viewModel = await _unitOfWork.UpdateAsync(viewModel);

        return Ok(viewModel);
    }
}