using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class EquipmentMapper
    {
        public static Equipment ToEquipment(this EquipmentRequest request)
        {
            return new Equipment
            {
                equipmentName = request.equipmentName,
                equipmentCode = request.equipmentCode,
                model = request.model,
                serialNumber = request.serialNumber,
                manufacturer = request.manufacturer,
                countryOfOrigin = request.countryOfOrigin,
                location = request.location,
                receivedDate = request.receivedDate,
                conditionWhenReceived = request.conditionWhenReceived,
                startDateOfUse = request.startDateOfUse,
                conditionWhenStarted = request.conditionWhenStarted,
                supplierName = request.supplierName,
                supplierAddress = request.supplierAddress,
                engineerInCharge = request.engineerInCharge,
                supplierPhone = request.supplierPhone,
                supplierEmail = request.supplierEmail,
                managers = request.managers.Select(m => new EquipmentManager
                {
                    userId = m.userId,
                    userName = m.userName,
                    fromDate = m.fromDate
                }).ToList(),

                maintenances = request.maintenances.Select(m => new EquipmentMaintenance
                {
                    maintenanceDate = m.maintenanceDate,
                    isIncident = m.isIncident,
                    isEngineerArrived = m.isEngineerArrived,
                    isCompleted = m.isCompleted,
                    actionType = m.actionType,
                    content = m.content,
                    purpose = m.purpose
                }).ToList(),
                isActive = request.isActive
            };
        }

        public static void UpdateEquipment(this Equipment entity, EquipmentRequest request)
        {
            entity.equipmentName = request.equipmentName;
            entity.equipmentCode = request.equipmentCode;
            entity.model = request.model;
            entity.serialNumber = request.serialNumber;
            entity.manufacturer = request.manufacturer;
            entity.countryOfOrigin = request.countryOfOrigin;
            entity.location = request.location;
            entity.receivedDate = request.receivedDate;
            entity.conditionWhenReceived = request.conditionWhenReceived;
            entity.startDateOfUse = request.startDateOfUse;
            entity.conditionWhenStarted = request.conditionWhenStarted;
            entity.supplierName = request.supplierName;
            entity.supplierAddress = request.supplierAddress;
            entity.engineerInCharge = request.engineerInCharge;
            entity.supplierPhone = request.supplierPhone;
            entity.supplierEmail = request.supplierEmail;
            entity.isActive = request.isActive;
            entity.managers = request.managers.Select(m => new EquipmentManager
            {
                userId = m.userId,
                userName = m.userName,
                fromDate = m.fromDate
            }).ToList();

            entity.maintenances = request.maintenances.Select(m => new EquipmentMaintenance
            {
                maintenanceDate = m.maintenanceDate,
                isIncident = m.isIncident,
                isEngineerArrived = m.isEngineerArrived,
                isCompleted = m.isCompleted,
                actionType = m.actionType,
                content = m.content,
                purpose = m.purpose,
                labSignature = m.labSignature,
                engineerSignature = m.engineerSignature
            }).ToList();
        }

        public static EquipmentResponseDto ToEquipmentResponse(this Equipment entity)
        {
            return new EquipmentResponseDto
            {
                id = entity.id,
                equipmentName = entity.equipmentName,
                equipmentCode = entity.equipmentCode,
                serialNumber = entity.serialNumber,
                location = entity.location,
                model = entity.model,
                manufacturer = entity.manufacturer,
                countryOfOrigin = entity.countryOfOrigin,
                receivedDate = entity.receivedDate,
                conditionWhenReceived = entity.conditionWhenReceived,
                startDateOfUse = entity.startDateOfUse,
                conditionWhenStarted = entity.conditionWhenStarted,
                supplierAddress = entity.supplierAddress,
                engineerInCharge = entity.engineerInCharge,
                supplierPhone = entity.supplierPhone,
                supplierEmail = entity.supplierEmail,
                supplierName = entity.supplierName,
                isActive = entity.isActive,
                managers = entity.managers?.Select(m => new EquipmentManagerResponseDto
                {
                    userId = m.userId,
                    userName = m.userName,
                    fromDate = m.fromDate
                }).ToList() ?? new List<EquipmentManagerResponseDto>(),

                maintenances = entity.maintenances?.Select(m => new EquipmentMaintenanceResponseDto
                {
                    maintenanceDate = m.maintenanceDate,
                    isIncident = m.isIncident ? "X" : "",
                    isEngineerArrived = m.isEngineerArrived ? "X" : "",
                    isCompleted = m.isCompleted ? "X" : "",
                    actionType = m.actionType,
                    isMaintenance = (m.actionType == "Bảo trì") ? "X" : "",
                    isRepair = (m.actionType == "Sửa chữa") ? "X" : "",
                    isCalibration = (m.actionType == "Hiệu chuẩn") ? "X" : "",
                    content = m.content,
                    purpose = m.purpose,
                    labSignature = m.labSignature,
                    engineerSignature = m.engineerSignature
                }).ToList() ?? new List<EquipmentMaintenanceResponseDto>()
            };
        }
    }
}