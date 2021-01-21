using Employes.Infrastructure.Domain;
using System.Collections.Generic;

namespace Employes.Infrastructure.Services.Interfaces
{
    public interface IEmployesService
    {
        /// <summary>
        /// Получение информации о сотруднике по ид записи
        /// </summary>
        /// <param name="employeId">Ид записи</param>
        /// <returns></returns>
        EmployesDomain GetEmployeById(int employeId);

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="employe">Сущность EmployesDomain</param>
        void AddEmploye(EmployesDomain employe);

        /// <summary>
        /// Получить всех сотрудников
        /// </summary>
        /// <returns></returns>
        List<EmployesDomain> GetAllEmployes();

        /// <summary>
        /// Получить всех неудаленных сотрудников
        /// </summary>
        /// <returns></returns>
        List<EmployesDomain> GetAllNotDeletedEmployes();

        /// <summary>
        /// Обновить информацию о сотруднике
        /// </summary>
        /// <param name="employeInfo">Сущность EmployesDomain</param>
        void UpdateEmployeInfo(EmployesDomain employeInfo);

        /// <summary>
        /// Удалить сотрудника по ид
        /// </summary>
        /// <param name="employeId">Ид сотрудника</param>
        void DeleteEmploye(int employeId);
    }
}
