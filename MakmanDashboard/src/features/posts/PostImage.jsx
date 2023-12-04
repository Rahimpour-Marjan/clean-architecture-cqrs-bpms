import styled from 'styled-components';

const Image = styled.img`
  border-radius: var(--border-radius-2);
`;

export const PostImage = ({ postImage }) => {
  return (
    <div>
      <Image src={postImage} alt='post-name' width={200} hight={200} />
    </div>
  );
};
