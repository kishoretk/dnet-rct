import { Box } from "@mui/material";
import TaskItemCard from "./TaskItemCard";
type Props = {
    taskitems: TaskItem[]
    selectTaskItem: (id: string) => void
}

export default function TaskItemList({ taskitems, selectTaskItem }: Props) {
    return (
        <Box sx={{ display: "flex", flexDirection: "column", gap: 3 }}>
            {taskitems.map((taskItem: TaskItem) => (
                <TaskItemCard
                    key={taskItem.id}
                    taskitem={taskItem}
                    selectTaskItem={selectTaskItem}
                />
            ))}
        </Box>
    )
}
