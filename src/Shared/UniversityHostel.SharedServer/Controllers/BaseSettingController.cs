namespace CommonLibrary.Server;

[ApiController]
public class BaseSettingController<TEntity> : ControllerBase
    where TEntity : BaseEntity
{
    private readonly IBaseSettingUnitOfWork<TEntity> _unitOfWork;
    private readonly IValidator<TEntity> _validator;

    public BaseSettingController(IBaseSettingUnitOfWork<TEntity> unitOfWork, IValidator<TEntity> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    [HttpGet]
    public virtual async Task<IActionResult> Get()
    {
        TEntity viewModel = await _unitOfWork.ReadAsync();
        return Ok(viewModel);
    }

    [HttpPut]
    public virtual async Task<IActionResult> Put(TEntity entity)
    {

        if (entity == null)
            return BadRequest("ViewModel can not be null");

        var result = _validator.Validate(entity);
        if (!result.IsValid)
        {
            string text = string.Join("-", result.Errors.Select(e => e.ErrorMessage));
            throw new Exception("NonValid ViewModel Reason:" + text);
        }

        entity = await _unitOfWork.UpdateAsync(entity);

        return Ok(entity);
    }
}